﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SinapsisEntities : DbContext
    {
        public SinapsisEntities()
            : base("name=SinapsisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tel_Carrito> tel_Carrito { get; set; }
        public virtual DbSet<tel_Carrito_Item> tel_Carrito_Item { get; set; }
        public virtual DbSet<tel_Clientes> tel_Clientes { get; set; }
        public virtual DbSet<tel_Pedidos> tel_Pedidos { get; set; }
        public virtual DbSet<tel_Productos> tel_Productos { get; set; }
        public virtual DbSet<tel_Sucursal> tel_Sucursal { get; set; }
        public virtual DbSet<tel_Empresa> tel_Empresa { get; set; }
        public virtual DbSet<Tel_Direcciones> Tel_Direcciones { get; set; }
        public virtual DbSet<tel_Familia> tel_Familia { get; set; }
        public virtual DbSet<tel_Grupo> tel_Grupo { get; set; }
        public virtual DbSet<tel_Linea> tel_Linea { get; set; }
        public virtual DbSet<tel_Precios> tel_Precios { get; set; }
        public virtual DbSet<tel_Combos> tel_Combos { get; set; }
        public virtual DbSet<tel_CombosDet> tel_CombosDet { get; set; }
        public virtual DbSet<tel_PedidosDet> tel_PedidosDet { get; set; }
        public virtual DbSet<tel_Comentarios> tel_Comentarios { get; set; }
        public virtual DbSet<tel_TipoReclamo> tel_TipoReclamo { get; set; }
        public virtual DbSet<tel_Ph_Interfase> tel_Ph_Interfase { get; set; }
        public virtual DbSet<sys_Menu> sys_Menu { get; set; }
        public virtual DbSet<sys_MenuDet> sys_MenuDet { get; set; }
        public virtual DbSet<tel_TipoPedido> tel_TipoPedido { get; set; }
        public virtual DbSet<tel_Opciones> tel_Opciones { get; set; }
        public virtual DbSet<tel_OpcionesDet> tel_OpcionesDet { get; set; }
        public virtual DbSet<tel_ProductoOpcion> tel_ProductoOpcion { get; set; }
        public virtual DbSet<sys_ReporteEmpresa> sys_ReporteEmpresa { get; set; }
        public virtual DbSet<sys_Reportes> sys_Reportes { get; set; }
        public virtual DbSet<sys_UsuarioEmpresa> sys_UsuarioEmpresa { get; set; }
        public virtual DbSet<UsersInfo> UsersInfoes { get; set; }
        public virtual DbSet<tel_Moviles> tel_Moviles { get; set; }
        public virtual DbSet<tel_TipoCliente> tel_TipoCliente { get; set; }
        public virtual DbSet<tel_FormaPago> tel_FormaPago { get; set; }
        public virtual DbSet<sys_ReportesGEO> sys_ReportesGEO { get; set; }
        public virtual DbSet<tel_Faltantes> tel_Faltantes { get; set; }
        public virtual DbSet<tel_Insumos> tel_Insumos { get; set; }
        public virtual DbSet<tel_Avisos> tel_Avisos { get; set; }
        public virtual DbSet<tel_Barrios> tel_Barrios { get; set; }
        public virtual DbSet<tel_Ciudades> tel_Ciudades { get; set; }
        public virtual DbSet<tel_MovilTracker> tel_MovilTracker { get; set; }
        public virtual DbSet<tel_ListaPrecio> tel_ListaPrecio { get; set; }
    
        public virtual ObjectResult<tel_Precios> App_GetPrecio(Nullable<int> idEmpresa, string idProducto, string idCanal, Nullable<int> idSucursal, Nullable<int> idCliente)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(string));
    
            var idCanalParameter = idCanal != null ?
                new ObjectParameter("IdCanal", idCanal) :
                new ObjectParameter("IdCanal", typeof(string));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tel_Precios>("App_GetPrecio", idEmpresaParameter, idProductoParameter, idCanalParameter, idSucursalParameter, idClienteParameter);
        }
    
        public virtual ObjectResult<tel_Precios> App_GetPrecio(Nullable<int> idEmpresa, string idProducto, string idCanal, Nullable<int> idSucursal, Nullable<int> idCliente, MergeOption mergeOption)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(string));
    
            var idCanalParameter = idCanal != null ?
                new ObjectParameter("IdCanal", idCanal) :
                new ObjectParameter("IdCanal", typeof(string));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tel_Precios>("App_GetPrecio", mergeOption, idEmpresaParameter, idProductoParameter, idCanalParameter, idSucursalParameter, idClienteParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> tel_ConfirmaCarrito(Nullable<int> idCarrito)
        {
            var idCarritoParameter = idCarrito.HasValue ?
                new ObjectParameter("IdCarrito", idCarrito) :
                new ObjectParameter("IdCarrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("tel_ConfirmaCarrito", idCarritoParameter);
        }
    
        public virtual ObjectResult<Tel_TableroPedidos_Result> Tel_TableroPedidos(Nullable<int> idSucursal, Nullable<int> idEmpresa)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Tel_TableroPedidos_Result>("Tel_TableroPedidos", idSucursalParameter, idEmpresaParameter);
        }
    
        public virtual ObjectResult<ph_Interfase_Result> ph_Interfase(Nullable<int> idPedido)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ph_Interfase_Result>("ph_Interfase", idPedidoParameter);
        }
    
        public virtual int tel_ActualizarEstado(Nullable<int> idPedido, string idEstado, Nullable<System.DateTime> fecha, string obs)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            var idEstadoParameter = idEstado != null ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var obsParameter = obs != null ?
                new ObjectParameter("Obs", obs) :
                new ObjectParameter("Obs", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tel_ActualizarEstado", idPedidoParameter, idEstadoParameter, fechaParameter, obsParameter);
        }
    
        public virtual ObjectResult<tel_Empresa> sys_rptGetEmpresas(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tel_Empresa>("sys_rptGetEmpresas", userNameParameter);
        }
    
        public virtual ObjectResult<tel_Empresa> sys_rptGetEmpresas(string userName, MergeOption mergeOption)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tel_Empresa>("sys_rptGetEmpresas", mergeOption, userNameParameter);
        }
    
        public virtual ObjectResult<sys_Reportes> sys_rptGetReportes(Nullable<int> idEmpresa)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sys_Reportes>("sys_rptGetReportes", idEmpresaParameter);
        }
    
        public virtual ObjectResult<sys_Reportes> sys_rptGetReportes(Nullable<int> idEmpresa, MergeOption mergeOption)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sys_Reportes>("sys_rptGetReportes", mergeOption, idEmpresaParameter);
        }
    
        public virtual int tel_AppCambiarSucursal(Nullable<int> idPedido, Nullable<int> idSucursal, string cuadrante)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var cuadranteParameter = cuadrante != null ?
                new ObjectParameter("Cuadrante", cuadrante) :
                new ObjectParameter("Cuadrante", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tel_AppCambiarSucursal", idPedidoParameter, idSucursalParameter, cuadranteParameter);
        }
    
        public virtual ObjectResult<tel_AppBuscaDireccion_Result> tel_AppBuscaDireccion(string dir1, string dir2, string dir3, string dir4)
        {
            var dir1Parameter = dir1 != null ?
                new ObjectParameter("Dir1", dir1) :
                new ObjectParameter("Dir1", typeof(string));
    
            var dir2Parameter = dir2 != null ?
                new ObjectParameter("Dir2", dir2) :
                new ObjectParameter("Dir2", typeof(string));
    
            var dir3Parameter = dir3 != null ?
                new ObjectParameter("Dir3", dir3) :
                new ObjectParameter("Dir3", typeof(string));
    
            var dir4Parameter = dir4 != null ?
                new ObjectParameter("Dir4", dir4) :
                new ObjectParameter("Dir4", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tel_AppBuscaDireccion_Result>("tel_AppBuscaDireccion", dir1Parameter, dir2Parameter, dir3Parameter, dir4Parameter);
        }
    
        public virtual ObjectResult<ph_Interfase_Result> ph_Interfase_V1(Nullable<int> idPedido)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ph_Interfase_Result>("ph_Interfase_V1", idPedidoParameter);
        }
    
        public virtual ObjectResult<tel_TableroKPI_Result> tel_TableroKPI(Nullable<int> idEmpresa, Nullable<System.DateTime> fecha)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tel_TableroKPI_Result>("tel_TableroKPI", idEmpresaParameter, fechaParameter);
        }
    
        public virtual ObjectResult<tel_TrearTableroPedido_Result> tel_TrearTableroPedido(Nullable<int> idEmpresa, Nullable<int> idSucursal)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tel_TrearTableroPedido_Result>("tel_TrearTableroPedido", idEmpresaParameter, idSucursalParameter);
        }
    
        public virtual int tel_AppAsignarMovil(Nullable<int> nroPedido, Nullable<int> idEmpresa, Nullable<int> idMovil, string operacion)
        {
            var nroPedidoParameter = nroPedido.HasValue ?
                new ObjectParameter("NroPedido", nroPedido) :
                new ObjectParameter("NroPedido", typeof(int));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idMovilParameter = idMovil.HasValue ?
                new ObjectParameter("IdMovil", idMovil) :
                new ObjectParameter("IdMovil", typeof(int));
    
            var operacionParameter = operacion != null ?
                new ObjectParameter("Operacion", operacion) :
                new ObjectParameter("Operacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tel_AppAsignarMovil", nroPedidoParameter, idEmpresaParameter, idMovilParameter, operacionParameter);
        }
    }
}