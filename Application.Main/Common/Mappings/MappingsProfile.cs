using Application.DTO;
using Application.DTO.ProductosDto;
using ApplicationUseCases.Productos.Commands.CreateProductoCommand;
using ApplicationUseCases.Productos.Commands.UpdateProductoCommand;
using AutoMapper;
using Domain.Entities;

namespace ApplicationUseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Producto, ProductoDto>()
            .ForMember(dest => dest.Tipo_Producto_Venta, opt => opt.MapFrom(src => src.Tipo_Producto_Venta));

            //CreateMap<Tipo_Producto_Venta, Tipo_Producto_VentaDto>().ReverseMap();
            //.ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src.Productos)); // Mapea la lista de productos

            CreateMap<UpdateProductoCommand, ProductoDto>().ReverseMap();
            CreateMap<CreateProductoCommand, Producto>().ReverseMap();

            CreateMap<Tipo_Producto_Venta, Tipo_Producto_VentaDto>().ReverseMap();

            CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }
}
