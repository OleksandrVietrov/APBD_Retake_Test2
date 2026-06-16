using TemplateApi.DTOs;

namespace TemplateApi.Services;

public interface IItemService
{
    Task<ItemGetDto?> GetItemAsync(int id);
    Task<OpResult> CreateItemAsync(int ownerId, CreateItemDto dto);
    
}

public enum OpResult
{
    Success,
    NotFound,
    Invalid,
    Conflict
}
