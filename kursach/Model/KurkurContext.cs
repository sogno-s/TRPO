using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kursach;

public partial class KurkurContext : DbContext
{
    public KurkurContext()
    {
    }

    public KurkurContext(DbContextOptions<KurkurContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Assembling> Assemblings { get; set; }

    public virtual DbSet<Categoryproduct> Categoryproducts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Informationofsupplier> Informationofsuppliers { get; set; }

    public virtual DbSet<Pasport> Pasports { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Paymentproduct> Paymentproducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supplierproduct> Supplierproducts { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kurkur;Username=postgres;Password=2609");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Idaddress).HasName("address_pkey");

            entity.ToTable("address");

            entity.Property(e => e.Idaddress)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idaddress");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Numberhouse)
                .HasMaxLength(6)
                .HasColumnName("numberhouse");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .HasColumnName("region");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Assembling>(entity =>
        {
            entity.HasKey(e => e.Idassembling).HasName("assembling_pkey");

            entity.ToTable("assembling");

            entity.Property(e => e.Idassembling)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idassembling");
            entity.Property(e => e.Dateofadmission).HasColumnName("dateofadmission");
            entity.Property(e => e.Idemployee).HasColumnName("idemployee");
            entity.Property(e => e.Idpayment).HasColumnName("idpayment");

            entity.HasOne(d => d.IdemployeeNavigation).WithMany(p => p.Assemblings)
                .HasForeignKey(d => d.Idemployee)
                .HasConstraintName("assembling_idemployee_fkey");

            entity.HasOne(d => d.IdpaymentNavigation).WithMany(p => p.Assemblings)
                .HasForeignKey(d => d.Idpayment)
                .HasConstraintName("assembling_idpayment_fkey");
        });

        modelBuilder.Entity<Categoryproduct>(entity =>
        {
            entity.HasKey(e => e.Idcategory).HasName("categoryproduct_pkey");

            entity.ToTable("categoryproduct");

            entity.Property(e => e.Idcategory)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idcategory");
            entity.Property(e => e.Namingcategory)
                .HasMaxLength(50)
                .HasColumnName("namingcategory");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Idcustomer).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Idcustomer)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idcustomer");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Idaddress).HasColumnName("idaddress");
            entity.Property(e => e.Idpasport).HasColumnName("idpasport");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(16)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdaddressNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Idaddress)
                .HasConstraintName("customer_idaddress_fkey");

            entity.HasOne(d => d.IdpasportNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Idpasport)
                .HasConstraintName("customer_idpasport_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Idemployee).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.Idemployee)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idemployee");
            entity.Property(e => e.Dateofbirthday).HasColumnName("dateofbirthday");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Idpasport).HasColumnName("idpasport");
            entity.Property(e => e.Idspecialization)
                .HasMaxLength(70)
                .HasColumnName("idspecialization");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Passworde)
                .HasMaxLength(20)
                .HasColumnName("passworde");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(16)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdpasportNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Idpasport)
                .HasConstraintName("employee_idpasport_fkey");
        });

        modelBuilder.Entity<Informationofsupplier>(entity =>
        {
            entity.HasKey(e => e.Idinformation).HasName("informationofsupplier_pkey");

            entity.ToTable("informationofsupplier");

            entity.Property(e => e.Idinformation)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idinformation");
            entity.Property(e => e.Accountnumbers)
                .HasMaxLength(50)
                .HasColumnName("accountnumbers");
            entity.Property(e => e.Dateendcooperation).HasColumnName("dateendcooperation");
            entity.Property(e => e.Dateofcooperation).HasColumnName("dateofcooperation");
            entity.Property(e => e.Fullnaming)
                .HasMaxLength(50)
                .HasColumnName("fullnaming");
            entity.Property(e => e.Monthlypayment)
                .HasColumnType("money")
                .HasColumnName("monthlypayment");
        });

        modelBuilder.Entity<Pasport>(entity =>
        {
            entity.HasKey(e => e.Idpasport).HasName("pasport_pkey");

            entity.ToTable("pasport");

            entity.Property(e => e.Idpasport)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idpasport");
            entity.Property(e => e.Numberp)
                .HasMaxLength(6)
                .HasColumnName("numberp");
            entity.Property(e => e.Seria)
                .HasMaxLength(4)
                .HasColumnName("seria");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Idpayment).HasName("payment_pkey");

            entity.ToTable("payment");

            entity.Property(e => e.Idpayment)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idpayment");
            entity.Property(e => e.Dateofpay).HasColumnName("dateofpay");
            entity.Property(e => e.Idemployee).HasColumnName("idemployee");
            entity.Property(e => e.Idstatus).HasColumnName("idstatus");
            entity.Property(e => e.Totalsumm)
                .HasColumnType("money")
                .HasColumnName("totalsumm");
            entity.Property(e => e.Typeofpay)
                .HasMaxLength(25)
                .HasColumnName("typeofpay");

            entity.HasOne(d => d.IdemployeeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Idemployee)
                .HasConstraintName("payment_idemployee_fkey");

            entity.HasOne(d => d.IdstatusNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Idstatus)
                .HasConstraintName("payment_idstatus_fkey");
        });

        modelBuilder.Entity<Paymentproduct>(entity =>
        {
            entity.HasKey(e => new { e.Idpayment, e.Idproduct }).HasName("paymentproduct_pkey");

            entity.ToTable("paymentproduct");

            entity.Property(e => e.Idpayment).HasColumnName("idpayment");
            entity.Property(e => e.Idproduct).HasColumnName("idproduct");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdpaymentNavigation).WithMany(p => p.Paymentproducts)
                .HasForeignKey(d => d.Idpayment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paymentproduct_idpayment_fkey");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.Paymentproducts)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paymentproduct_idproduct_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Idproduct)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idproduct");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Idcategory).HasColumnName("idcategory");
            entity.Property(e => e.Idwarehouse).HasColumnName("idwarehouse");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(50)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Naming)
                .HasMaxLength(50)
                .HasColumnName("naming");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idcategory)
                .HasConstraintName("product_idcategory_fkey");

            entity.HasOne(d => d.IdwarehouseNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idwarehouse)
                .HasConstraintName("product_idwarehouse_fkey");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Idspecialization).HasName("specialization_pkey");

            entity.ToTable("specialization");

            entity.Property(e => e.Idspecialization)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idspecialization");
            entity.Property(e => e.Naming)
                .HasMaxLength(25)
                .HasColumnName("naming");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Idstatus).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.Idstatus)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idstatus");
            entity.Property(e => e.Naming)
                .HasColumnType("character varying")
                .HasColumnName("naming");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Idsupplier).HasName("supplier_pkey");

            entity.ToTable("supplier");

            entity.Property(e => e.Idsupplier)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idsupplier");
            entity.Property(e => e.Idinformation).HasColumnName("idinformation");
            entity.Property(e => e.Naming)
                .HasMaxLength(50)
                .HasColumnName("naming");
            entity.Property(e => e.Surnameresponsible)
                .HasMaxLength(50)
                .HasColumnName("surnameresponsible");

            entity.HasOne(d => d.IdinformationNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.Idinformation)
                .HasConstraintName("supplier_idinformation_fkey");
        });

        modelBuilder.Entity<Supplierproduct>(entity =>
        {
            entity.HasKey(e => e.Idsupprod).HasName("supplierproduct_pkey");

            entity.ToTable("supplierproduct");

            entity.Property(e => e.Idsupprod)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idsupprod");

            entity.Property(e => e.Idsupplier).HasColumnName("idsupplier");
            entity.Property(e => e.Idproduct).HasColumnName("idproduct");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.Supplierproducts)
                .HasForeignKey(d => d.Idproduct)
                .HasConstraintName("supplierproduct_idproduct_fkey");

            entity.HasOne(d => d.IdsupplierNavigation).WithMany(p => p.Supplierproducts)
                .HasForeignKey(d => d.Idsupplier)
                .HasConstraintName("supplierproduct_idsupplier_fkey");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Idwarehouse).HasName("warehouse_pkey");

            entity.ToTable("warehouse");

            entity.Property(e => e.Idwarehouse)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idwarehouse");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.Dateofreceipt).HasColumnName("dateofreceipt");
            entity.Property(e => e.Idsupplier).HasColumnName("idsupplier");
            entity.Property(e => e.Inventorynumber)
                .HasMaxLength(50)
                .HasColumnName("inventorynumber");

            entity.HasOne(d => d.IdsupplierNavigation).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.Idsupplier)
                .HasConstraintName("warehouse_idsupplier_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
