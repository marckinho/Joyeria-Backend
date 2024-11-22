using Application.DTO;
using Application.DTO.ProductosDto;
using ApplicationUseCases.Customers.Commands.CreateCustomerCommand;
using ApplicationUseCases.Customers.Commands.UpdateCustomerCommand;
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
            /*CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            
            //CreateMap<ProductoDto, CreateProductoCommand>().ReverseMap();
            CreateMap<UpdateProductoCommand, ProductoDto>().ReverseMap();
            CreateMap<CreateProductoCommand, Producto>().ReverseMap();

            //CreateMap<CreateProductoCommand, ProductoDto>()
            //.ForMember(dest => dest.Tipo_Producto_Venta_Nombre, opt => opt.Ignore()); // Ignorado porque no existe en la fuente

            CreateMap<Customer,CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer,UpdateCustomerCommand>().ReverseMap();


            CreateMap<Tipo_Producto_Venta, Tipo_Producto_VentaDto>().ReverseMap();

            CreateMap<Producto, ProductoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo))
            .ForMember(dest => dest.Tipo_Producto_Venta_Id, opt => opt.MapFrom(src => src.Tipo_Producto_Venta != null ? src.Tipo_Producto_Venta.Id : (int?)null))
            // Mapea solo el ID de TipoProductoVenta
            .ForMember(dest => dest.Tipo_Producto_Venta_Nombre,
                       opt => opt.MapFrom(src => src.Tipo_Producto_Venta != null ? src.Tipo_Producto_Venta.Nombre : null));*/

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Producto, ProductoDto>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
    .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo))
    .ForMember(dest => dest.Tipo_Producto_Venta_Id, opt => opt.MapFrom(src => src.Tipo_Producto_Venta.Id)) // Solo mapea el ID de Tipo_Producto_Venta
    .ForMember(dest => dest.Tipo_Producto_Venta_Nombre, opt => opt.MapFrom(src => src.Tipo_Producto_Venta.Nombre)) // Mapea solo el nombre
    .ForMember(dest => dest.Tipo_Producto_Venta, opt => opt.Ignore()); // Ignora la propiedad de navegación completa 'Tipo_Producto_Venta'

            CreateMap<Producto, ProductoTipoVentaDto>()
            .ForMember(dest => dest.Tipo_Producto_Venta, opt => opt.MapFrom(src => src.Tipo_Producto_Venta));


            CreateMap<Tipo_Producto_Venta, Tipo_Producto_VentaDto>()
    .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src.Productos)); // Mapea la lista de productos


            // Mapear UpdateProductoCommand a Producto
            CreateMap<UpdateProductoCommand, ProductoDto>().ReverseMap();
            CreateMap<CreateProductoCommand, Producto>().ReverseMap();

            // Otros mapeos...
            //CreateMap<Tipo_Producto_Venta, Tipo_Producto_VentaDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        }
    }
}
