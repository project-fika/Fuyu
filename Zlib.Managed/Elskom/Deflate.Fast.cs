// Copyright (c) 2018-2020, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: see LICENSE for more details.

namespace Elskom.Generic.Libs
{
    /// <summary>
    /// Class for compressing data through zlib.
    /// </summary>
    internal sealed partial class Deflate
    {
        // Compress as much as possible from the input stream, return the current
        // block state.
        // This function does not perform lazy evaluation of matches and inserts
        // new strings in the dictionary only for unmatched strings or for short
        // matches. It is used only for the fast compression options.
        internal int Deflate_fast(int flush)
        {
            // short hash_head = 0; // head of the hash chain
            var hash_head = 0; // head of the hash chain
            bool bflush; // set if current block must be flushed

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
                // At this point we have always match_length < MIN_MATCH
                if (hash_head != 0L && ((this.Strstart - hash_head) & 0xffff) <= this.WSize - MINLOOKAHEAD)
                {
                    // To simplify the code, we prevent matches with the string
                    // of window index 0 (in particular we have to avoid a match
                    // of the string with itself at the start of the input file).
                    if (this.Strategy != ZHUFFMANONLY)
                    {
                        this.MatchLength = this.Longest_match(hash_head);
                    }

                    // longest_match() sets match_start
                }

                if (this.MatchLength >= MINMATCH)
                {
                    // check_match(strstart, match_start, match_length);
                    bflush = this.Tr_tally(this.Strstart - this.MatchStart, this.MatchLength - MINMATCH);

                    this.Lookahead -= this.MatchLength;

                    // Insert new strings in the hash table only if the match length
                    // is not too large. This saves time but degrades compression.
                    if (this.MatchLength <= this.MaxLazyMatch && this.Lookahead >= MINMATCH)
                    {
                        this.MatchLength--; // string at strstart already in hash table
                        do
                        {
                            this.Strstart++;

                            this.InsH = ((this.InsH << this.HashShift) ^ (this.Window[this.Strstart + (MINMATCH - 1)] & 0xff)) & this.HashMask;

                            // prev[strstart&w_mask]=hash_head=head[ins_h];
                            hash_head = this.Head[this.InsH] & 0xffff;
                            this.Prev[this.Strstart & this.WMask] = this.Head[this.InsH];
                            this.Head[this.InsH] = (short)this.Strstart;

                            // strstart never exceeds WSIZE-MAX_MATCH, so there are
                            // always MIN_MATCH bytes ahead.
                        }
                        while (--this.MatchLength != 0);
                        this.Strstart++;
                    }
                    else
                    {
                        this.Strstart += this.MatchLength;
                        this.MatchLength = 0;
                        this.InsH = this.Window[this.Strstart] & 0xff;

                        this.InsH = ((this.InsH << this.HashShift) ^ (this.Window[this.Strstart + 1] & 0xff)) & this.HashMask;

                        // If lookahead < MIN_MATCH, ins_h is garbage, but it does not
                        // matter since it will be recomputed at next deflate call.
                    }
                }
                else
                {
                    // No match, output a literal byte
                    bflush = this.Tr_tally(0, this.Window[this.Strstart] & 0xff);
                    this.Lookahead--;
                    this.Strstart++;
                }

                if (bflush)
                {
                    this.Flush_block_only(false);
                    if (this.Strm.AvailOut == 0)
                    {
                        return NeedMore;
                    }
                }
            }

            this.Flush_block_only(flush == ZFINISH);
            return this.Strm.AvailOut == 0 ? flush == ZFINISH ? FinishStarted : NeedMore : flush == ZFINISH ? FinishDone : BlockDone;
        }
    }
}