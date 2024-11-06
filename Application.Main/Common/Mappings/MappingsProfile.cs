using Application.DTO;
using ApplicationUseCases.Customers.Commands.CreateCustomerCommand;
using ApplicationUseCases.Customers.Commands.UpdateCustomerCommand;
using AutoMapper;
using Domain.Entities;

namespace ApplicationUseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();

            CreateMap<Customer,CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer,UpdateCustomerCommand>().ReverseMap();

            CreateMap<Tipo_Producto_Venta, Tipo_Producto_VentaDto>();

            CreateMap<Producto, ProductoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo))
            .ForMember(dest => dest.Tipo_Producto_Venta_Id,
                       opt => opt.MapFrom(src => src.Tipo_Producto_Venta.Id)) // Mapea solo el ID de TipoProductoVenta
            .ForMember(dest => dest.Tipo_Producto_Venta_Nombre,
               opt => opt.MapFrom(src => src.Tipo_Producto_Venta.Nombre));

        }
    }
}
