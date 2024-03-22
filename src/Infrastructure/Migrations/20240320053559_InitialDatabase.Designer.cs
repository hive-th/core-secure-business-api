﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.AuthAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate;
using Core.Secure.Business.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Core.Secure.Business.Infrastructure.Migrations
{
    [DbContext(typeof(BusinessDbContext))]
    [Migration("20240320053559_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uuid")
                        .HasColumnName("buyer_id");

                    b.Property<string>("CartType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cart_type");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<List<Dealer>>("Dealers")
                        .HasColumnType("jsonb")
                        .HasColumnName("dealers");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text")
                        .HasColumnName("deleted_by");

                    b.Property<string>("GuestId")
                        .HasColumnType("text")
                        .HasColumnName("guest_id");

                    b.Property<List<Promotion>>("Promotions")
                        .HasColumnType("jsonb")
                        .HasColumnName("promotions");

                    b.Property<Summary>("Summary")
                        .HasColumnType("jsonb")
                        .HasColumnName("summary");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_cart");

                    b.ToTable("cart", (string)null);
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.LogSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ObjectType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("object_type");

                    b.Property<string>("ObjectValue")
                        .HasColumnType("jsonb")
                        .HasColumnName("object_value");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("text")
                        .HasColumnName("reference_id");

                    b.Property<string>("ReferenceType")
                        .HasColumnType("text")
                        .HasColumnName("reference_type");

                    b.Property<string>("Source")
                        .HasColumnType("text")
                        .HasColumnName("source");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_log_system");

                    b.ToTable("log_system", (string)null);
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text")
                        .HasColumnName("deleted_by");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("numeric")
                        .HasColumnName("grand_total");

                    b.Property<string>("OrderNo")
                        .HasColumnType("text")
                        .HasColumnName("order_no");

                    b.Property<Guid>("OrderRequestId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_request_id");

                    b.Property<Payment>("Payment")
                        .HasColumnType("jsonb")
                        .HasColumnName("payment");

                    b.Property<PaymentChargeResponse>("PaymentCharge")
                        .HasColumnType("jsonb")
                        .HasColumnName("payment_charge");

                    b.Property<string>("PaymentChargeNo")
                        .HasColumnType("text")
                        .HasColumnName("payment_charge_no");

                    b.Property<ShippingLocation>("ShippingLocation")
                        .HasColumnType("jsonb")
                        .HasColumnName("shipping_location");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<TaxLocation>("TaxLocation")
                        .HasColumnType("jsonb")
                        .HasColumnName("tax_location");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount");

                    b.Property<decimal?>("TotalAmountExceptVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_except_vat");

                    b.Property<decimal?>("TotalAmountExceptVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_except_vat_discounted");

                    b.Property<decimal?>("TotalAmountExcludeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_exclude_vat");

                    b.Property<decimal?>("TotalAmountExcludeVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_exclude_vat_discounted");

                    b.Property<decimal?>("TotalAmountIncludeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_include_vat");

                    b.Property<decimal?>("TotalAmountIncludeVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_include_vat_discounted");

                    b.Property<decimal?>("TotalAmountVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_vat");

                    b.Property<decimal?>("TotalAmountVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_vat_discounted");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_discount");

                    b.Property<decimal>("TotalItemsDiscount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_items_discount");

                    b.Property<decimal?>("TotalShippingDiscount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_discount");

                    b.Property<decimal?>("TotalShippingFee")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_fee");

                    b.Property<decimal?>("TotalShippingFeeExcludeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_fee_exclude_vat");

                    b.Property<decimal?>("TotalShippingFeeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_fee_vat");

                    b.Property<decimal>("TotalVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_vat");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_order");

                    b.HasIndex("OrderRequestId")
                        .HasDatabaseName("ix_order_order_request_id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.OrderDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text")
                        .HasColumnName("deleted_by");

                    b.Property<string>("DocumentNo")
                        .HasColumnType("text")
                        .HasColumnName("document_no");

                    b.Property<int>("DocumentType")
                        .HasColumnType("integer")
                        .HasColumnName("document_type");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<string>("RefDocumentNo")
                        .HasColumnType("text")
                        .HasColumnName("ref_document_no");

                    b.Property<int>("RefDocumentType")
                        .HasColumnType("integer")
                        .HasColumnName("ref_document_type");

                    b.Property<Guid>("SuborderId")
                        .HasColumnType("uuid")
                        .HasColumnName("suborder_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_order_document");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_document_order_id");

                    b.HasIndex("SuborderId")
                        .HasDatabaseName("ix_order_document_suborder_id");

                    b.ToTable("order_document");
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.OrderRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<AuthAccount>("Buyer")
                        .HasColumnType("jsonb")
                        .HasColumnName("buyer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text")
                        .HasColumnName("deleted_by");

                    b.Property<string>("OrderRequestNo")
                        .HasColumnType("text")
                        .HasColumnName("order_request_no");

                    b.Property<CartDetailPromotion>("Promotion")
                        .HasColumnType("jsonb")
                        .HasColumnName("promotion");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_order_request");

                    b.ToTable("order_request", (string)null);
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Suborder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text")
                        .HasColumnName("deleted_by");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("numeric")
                        .HasColumnName("grand_total");

                    b.Property<List<SuborderItem>>("Items")
                        .HasColumnType("jsonb")
                        .HasColumnName("items");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<CartDetailPromotion>("Promotion")
                        .HasColumnType("jsonb")
                        .HasColumnName("promotion");

                    b.Property<string>("ShippingType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("shipping_type");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<CartPromotionSubcartDiscountResponse>("SuborderDiscount")
                        .HasColumnType("jsonb")
                        .HasColumnName("suborder_discount");

                    b.Property<string>("SuborderNo")
                        .HasColumnType("text")
                        .HasColumnName("suborder_no");

                    b.Property<string>("SuborderType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("suborder_type");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount");

                    b.Property<decimal?>("TotalAmountExceptVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_except_vat");

                    b.Property<decimal?>("TotalAmountExceptVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_except_vat_discounted");

                    b.Property<decimal?>("TotalAmountExcludeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_exclude_vat");

                    b.Property<decimal?>("TotalAmountExcludeVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_exclude_vat_discounted");

                    b.Property<decimal?>("TotalAmountIncludeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_include_vat");

                    b.Property<decimal?>("TotalAmountIncludeVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_include_vat_discounted");

                    b.Property<decimal?>("TotalAmountVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_vat");

                    b.Property<decimal?>("TotalAmountVatDiscounted")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount_vat_discounted");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_discount");

                    b.Property<decimal>("TotalItemsDiscount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_items_discount");

                    b.Property<decimal?>("TotalShippingDiscount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_discount");

                    b.Property<decimal?>("TotalShippingFee")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_fee");

                    b.Property<decimal?>("TotalShippingFeeExcludeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_fee_exclude_vat");

                    b.Property<decimal?>("TotalShippingFeeVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_shipping_fee_vat");

                    b.Property<decimal>("TotalVat")
                        .HasColumnType("numeric")
                        .HasColumnName("total_vat");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_suborder");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_suborder_order_id");

                    b.ToTable("suborder", (string)null);
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Order", b =>
                {
                    b.HasOne("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.OrderRequest", "OrderRequests")
                        .WithMany("Orders")
                        .HasForeignKey("OrderRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_order_request_order_request_id");

                    b.Navigation("OrderRequests");
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.OrderDocument", b =>
                {
                    b.HasOne("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Order", "Orders")
                        .WithMany("OrderDocuments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_document_order_order_id");

                    b.HasOne("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Suborder", "Suborders")
                        .WithMany("OrderDocuments")
                        .HasForeignKey("SuborderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_document_suborder_suborder_id");

                    b.Navigation("Orders");

                    b.Navigation("Suborders");
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Suborder", b =>
                {
                    b.HasOne("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Order", "Orders")
                        .WithMany("Suborders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_suborder_order_order_id");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Order", b =>
                {
                    b.Navigation("OrderDocuments");

                    b.Navigation("Suborders");
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.OrderRequest", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Core.Secure.Business.Domain.AggregatesModel.EntityAggregate.Suborder", b =>
                {
                    b.Navigation("OrderDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}