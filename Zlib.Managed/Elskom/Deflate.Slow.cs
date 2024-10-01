namespace Elskom.Generic.Libs
{
    internal sealed partial class Deflate
    {
        // Same as above, but achieves better compression. We use a lazy
        // evaluation for matches: a match is finally adopted only if there is
        // no better match at the next window position.
        internal int Deflate_slow(int flush)
        {
            // short hash_head = 0;    // head of hash chain
            var hash_head = 0; // head of hash chain
            bool bflush; // set if current block must be flushed

            // Process the input block.
            while (true)
            {
                // Make sure that we always have enough lookahead, except
                // at the end of the input file. We need MAX_MATCH bytes
                // for the next match, plus MIN_MATCH bytes to insert the
                // string following the next match.
                if (this.Lookahead < MINLOOKAHEAD)
                {
                    this.Fill_window();
                    if (this.Lookahead < MINLOOKAHEAD && flush == ZNOFLUSH)
                    {
                        return NeedMore;
                    }

                    if (this.Lookahead == 0)
                    {
                        break; // flush the current block
                    }
                }

                // Insert the string window[strstart .. strstart+2] in the
                // dictionary, and set hash_head to the head of the hash chain:
                if (this.Lookahead >= MINMATCH)
                {
                    this.InsH = ((this.InsH << this.HashShift) ^ (this.Window[this.Strstart + (MINMATCH - 1)] & 0xff)) & this.HashMask;

                    // prev[strstart&w_mask]=hash_head=head[ins_h];
                    hash_head = this.Head[this.InsH] & 0xffff;
                    this.Prev[this.Strstart & this.WMask] = this.Head[this.InsH];
                    this.Head[this.InsH] = (short)this.Strstart;
                }

                // Find the longest match, discarding those <= prev_length.
                this.PrevLength = this.MatchLength;
                this.PrevMatch = this.MatchStart;
                this.MatchLength = MINMATCH - 1;

                if (hash_head != 0 && this.PrevLength < this.MaxLazyMatch && ((this.Strstart - hash_head) & 0xffff) <= this.WSize - MINLOOKAHEAD)
                {
                    // To simplify the code, we prevent matches with the string
                    // of window index 0 (in particular we have to avoid a match
                    // of the string with itself at the start of the input file).
                    if (this.Strategy != ZHUFFMANONLY)
                    {
                        this.MatchLength = this.Longest_match(hash_head);
                    }

                    // longest_match() sets match_start
                    if (this.MatchLength <= 5 && (this.Strategy == ZFILTERED || (this.MatchLength == MINMATCH && this.Strstart - this.MatchStart > 4096)))
                    {
                        // If prev_match is also MIN_MATCH, match_start is garbage
                        // but we will ignore the current match anyway.
                        this.MatchLength = MINMATCH - 1;
                    }
                }

                // If there was a match at the previous step and the current
                // match is not better, output the previous match:
                if (this.PrevLength >= MINMATCH && this.MatchLength <= this.PrevLength)
                {
                    var max_insert = this.Strstart + this.Lookahead - MINMATCH;

                    // Do not insert strings in hash table beyond this.

                    // check_match(strstart-1, prev_match, prev_length);
                    bflush = this.Tr_tally(this.Strstart - 1 - this.PrevMatch, this.PrevLength - MINMATCH);

                    // Insert in hash table all strings up to the end of the match.
                    // strstart-1 and strstart are already inserted. If there is not
                    // enough lookahead, the last two strings are not inserted in
                    // the hash table.
                    this.Lookahead -= this.PrevLength - 1;
                    this.PrevLength -= 2;
                    do
                    {
                        if (++this.Strstart <= max_insert)
                        {
                            this.InsH = ((this.InsH << this.HashShift) ^ (this.Window[this.Strstart + (MINMATCH - 1)] & 0xff)) & this.HashMask;

                            // prev[strstart&w_mask]=hash_head=head[ins_h];
                            hash_head = this.Head[this.InsH] & 0xffff;
                            this.Prev[this.Strstart & this.WMask] = this.Head[this.InsH];
                            this.Head[this.InsH] = (short)this.Strstart;
                        }
                    }
                    while (--this.PrevLength != 0);
                    this.MatchAvailable = 0;
                    this.MatchLength = MINMATCH - 1;
                    this.Strstart++;

                    if (bflush)
                    {
                        this.Flush_block_only(false);
                        if (this.Strm.AvailOut == 0)
                        {
                            return NeedMore;
                        }
                    }
                }
                else if (this.MatchAvailable != 0)
                {
                    // If there was no match at the previous position, output a
                    // single literal. If there was a match but the current match
                    // is longer, truncate the previous match to a single literal.
                    bflush = this.Tr_tally(0, this.Window[this.Strstart - 1] & 0xff);

                    if (bflush)
                    {
                        this.Flush_block_only(false);
                    }

                    this.Strstart++;
                    this.Lookahead--;
                    if (this.Strm.AvailOut == 0)
                    {
                        return NeedMore;
                    }
                }
                else
                {
                    // There is no previous match to compare with, wait for
                    // the next step to decide.
                    this.MatchAvailable = 1;
                    this.Strstart++;
                    this.Lookahead--;
                }
            }

            if (this.MatchAvailable != 0)
            {
                bflush = this.Tr_tally(0, this.Window[this.Strstart - 1] & 0xff);
                this.MatchAvailable = 0;
            }

            this.Flush_block_only(flush == ZFINISH);

            return this.Strm.AvailOut == 0 ? flush == ZFINISH ? FinishStarted : NeedMore : flush == ZFINISH ? FinishDone : BlockDone;
        }
    }
}