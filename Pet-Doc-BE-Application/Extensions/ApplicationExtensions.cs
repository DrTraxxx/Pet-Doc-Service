using AutoMapper;

namespace Pet_Doc_BE_Application.Extensions;

public static class ApplicationExtensions
{
    public static TDest MapTo<TDest,TSourse>(this TSourse source, IMapper mapper)
        => mapper.Map<TDest>(source);
}
