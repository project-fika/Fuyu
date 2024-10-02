namespace Elskom.Generic.Libs
{
    internal sealed partial class Deflate
    {
        // Copy without compression as much as possible from the input stream, return
        // the current block state.
        // This function does not insert new strings in the dictionary since
        // uncompressible data is probably not useful. This function is used
        // only for the level=0 compression option.
        // NOTE: this function should be optimized to avoid extra copying from
        // window to pending_buf.
        internal int Deflate_stored(int flush)
        {
            // Stored blocks are limited to 0xffff bytes, pending_buf is limited
            // to pending_buf_size, and each stored block has a 5 byte header:
            var max_block_size = 0xffff;
            int max_start;

            if (max_block_size > this.PendingBufSize - 5)
            {
                max_block_size = this.PendingBufSize - 5;
            }

            // Copy as much as possible from input to output:
            while (true)
            {
                // Fill the window as much as possible:
                if (this.Lookahead <= 1)
                {
                    this.Fill_window();
                    if (this.Lookahead == 0 && flush == ZNOFLUSH)
                    {
                        return NeedMore;
                    }

                    if (this.Lookahead == 0)
                    {
                        break; // flush the current block
                    }
                }

                this.Strstart += this.Lookahead;
                this.Lookahead = 0;

                // Emit a stored block if pending_buf will be full:
                max_start = this.BlockStart + max_block_size;
                if (this.Strstart == 0 || this.Strstart >= max_start)
                {
                    // strstart == 0 is possible when wraparound on 16-bit machine
                    this.Lookahead = this.Strstart - max_start;
                    this.Strstart = max_start;

                    this.Flush_block_only(false);
                    if (this.Strm.AvailOut == 0)
                    {
                        return NeedMore;
                    }
                }

                // Flush if we may have to slide, otherwise block_start may become
                // negative and the data will be gone:
                if (this.Strstart - this.BlockStart >= this.WSize - MINLOOKAHEAD)
                {
                    this.Flush_block_only(false);
                    if (this.Strm.AvailOut == 0)
                    {
                        return NeedMore;
                    }
                }
            }

            this.Flush_block_only(flush == ZFINISH);
            return this.Strm.AvailOut == 0 ? (flush == ZFINISH) ? FinishStarted : NeedMore : flush == ZFINISH ? FinishDone : BlockDone;
        }
    }
}