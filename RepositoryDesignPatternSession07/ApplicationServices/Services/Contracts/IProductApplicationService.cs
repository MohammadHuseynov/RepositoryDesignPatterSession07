using RepositoryDesignPatternSession07.ApplicationServices.Dtos;

namespace RepositoryDesignPatternSession07.ApplicationServices.Services.Contracts
{
    public interface IProductApplicationService
    {
        // CREATE: A method that takes the create DTO.
        void PostProductDto(PostProductDto postProductDto);

        // READ: Methods that return the read DTO.
        GetProductDto GetById(Guid id); // Use Guid to match your DTOs
        List<GetProductDto> GetAll();

        // UPDATE: A method that takes the update DTO.
        void UpdateProductDto(UpdateProductDto updateProductDto);

        // DELETE: A method that takes the Id.
        void Delete(Guid id); // Use Guid
    }
}

