namespace PromocodeFactoryApi.Commands
{
    public class CreatePreferenceCommand
    {
        public string Name { get; set; }

        public List<Guid> CustomerIds { get; set; }
        public List<Guid> PromoCodeIds { get; set; }

    }
}
