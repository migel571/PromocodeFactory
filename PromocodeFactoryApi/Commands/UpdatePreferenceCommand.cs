namespace PromocodeFactoryApi.Commands
{
    public class UpdatePreferenceCommand
    {
        public Guid PreferenceId { get; set; }
        public string Name { get; set; }

        public List<Guid> CustomerIds { get; set; }
        public List<Guid> PromoCodeIds { get; set; }
    }
}
