using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.DAL
{
    public class WineDbContext : IdentityDbContext<AppUser>
    {
        public WineDbContext(DbContextOptions<WineDbContext> options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<IntroSlider> IntroSliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColorSize> ProductColorSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeOurClientsSlider> HomeOurClientsSliders { get; set; }
        public DbSet<HomeSpecialCards> HomeSpecialCards { get; set; }
        public DbSet<HomeGallery> HomeGalleries { get; set; }
        public DbSet<HomeCounts> HomeCounts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
