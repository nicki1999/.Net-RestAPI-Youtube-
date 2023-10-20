namespace Catalog.Dtos{
        public record ItemDto
    {
        public Guid Id{get; init;}

        public required string Name{get; init;}
        public required decimal Price{get; init;}
        public required DateTimeOffset CreatedDate {get; init;}

    }
}