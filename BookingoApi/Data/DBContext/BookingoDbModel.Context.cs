﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingoApi.Data.DBContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BookingoEntities : DbContext
    {
        public BookingoEntities()
            : base("name=BookingoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
    
        public virtual ObjectResult<GetFreeHotels_Result> GetFreeHotels(Nullable<short> guest, Nullable<int> idCity, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var guestParameter = guest.HasValue ?
                new ObjectParameter("guest", guest) :
                new ObjectParameter("guest", typeof(short));
    
            var idCityParameter = idCity.HasValue ?
                new ObjectParameter("idCity", idCity) :
                new ObjectParameter("idCity", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFreeHotels_Result>("GetFreeHotels", guestParameter, idCityParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<GetFreeHotelRooms_Result> GetFreeHotelRooms(Nullable<short> guest, Nullable<long> idHotel, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var guestParameter = guest.HasValue ?
                new ObjectParameter("guest", guest) :
                new ObjectParameter("guest", typeof(short));
    
            var idHotelParameter = idHotel.HasValue ?
                new ObjectParameter("idHotel", idHotel) :
                new ObjectParameter("idHotel", typeof(long));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFreeHotelRooms_Result>("GetFreeHotelRooms", guestParameter, idHotelParameter, startDateParameter, endDateParameter);
        }
    }
}
