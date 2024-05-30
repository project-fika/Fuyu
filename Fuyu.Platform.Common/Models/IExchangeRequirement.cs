using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models
{
    public interface IExchangeRequirement
    {
        ItemInstance Item { get; } //in the assembly its an Item, but 

        string TemplateId { get; }

        string ItemName { get; }

        int IntCount { get; }

        double PreciseCount { get; }

        bool OnlyFunctional { get; }

        bool IsEncoded { get; }
    }
}