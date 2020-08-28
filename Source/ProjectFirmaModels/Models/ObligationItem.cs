namespace ProjectFirmaModels.Models
{
    public partial class ObligationItem
    {
        public string GetDisplayName() => $"{this.ObligationNumber.ObligationNumberKey} - {this.ObligationItemKey}";
    }
}