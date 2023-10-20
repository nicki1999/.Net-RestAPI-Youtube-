using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        public required string Name{get; init;}

        [Range(1,1000)]
        public required decimal Price{get; init;}
    }
}