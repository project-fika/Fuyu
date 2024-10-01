namespace Elskom.Generic.Libs
{
    internal class Config
    {
        internal Config(int good_length, int max_lazy, int nice_length, int max_chain, int func)
        {
            this.GoodLength = good_length;
            this.MaxLazy = max_lazy;
            this.NiceLength = nice_length;
            this.MaxChain = max_chain;
            this.Func = func;
        }

        // reduce lazy search above this match length
        internal int GoodLength { get; set; }

        // do not perform lazy search above this match length
        internal int MaxLazy { get; set; }

        // quit search above this match length
        internal int NiceLength { get; set; }

        internal int MaxChain { get; set; }

        internal int Func { get; set; }
    }
}