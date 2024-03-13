using System;
using System.Collections.Generic;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.AuthAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Secure.Business.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cart_type = table.Column<CartType>(type: "jsonb", nullable: false),
                    detail = table.Column<CartDetail>(type: "jsonb", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    guest_id = table.Column<string>(type: "text", nullable: true),
                    buyer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "log_system",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    reference_type = table.Column<string>(type: "text", nullable: true),
                    reference_id = table.Column<string>(type: "text", nullable: true),
                    source = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    object_type = table.Column<string>(type: "text", nullable: false),
                    object_value = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_log_system", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_request",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_request_no = table.Column<string>(type: "text", nullable: true),
                    promotion = table.Column<CartDetailPromotion>(type: "jsonb", nullable: true),
                    buyer = table.Column<AuthAccount>(type: "jsonb", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_request", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_no = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    shipping_location = table.Column<ShippingLocation>(type: "jsonb", nullable: true),
                    tax_location = table.Column<TaxLocation>(type: "jsonb", nullable: true),
                    payment = table.Column<Payment>(type: "jsonb", nullable: true),
                    payment_charge = table.Column<PaymentChargeResponse>(type: "jsonb", nullable: true),
                    payment_charge_no = table.Column<string>(type: "text", nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_amount_except_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_except_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_include_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_include_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_exclude_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_exclude_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_fee_exclude_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_fee_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_discount = table.Column<decimal>(type: "numeric", nullable: true),
                    total_vat = table.Column<decimal>(type: "numeric", nullable: false),
                    total_discount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_items_discount = table.Column<decimal>(type: "numeric", nullable: false),
                    grand_total = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_order_request_order_request_id",
                        column: x => x.order_request_id,
                        principalTable: "order_request",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "suborder",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    suborder_no = table.Column<string>(type: "text", nullable: true),
                    suborder_type = table.Column<SuborderType>(type: "jsonb", nullable: false),
                    shipping_type = table.Column<ShippingType>(type: "jsonb", nullable: false),
                    status = table.Column<OrderStatus>(type: "jsonb", nullable: false),
                    promotion = table.Column<CartDetailPromotion>(type: "jsonb", nullable: true),
                    suborder_discount = table.Column<CartPromotionSubcartDiscountResponse>(type: "jsonb", nullable: true),
                    items = table.Column<List<SuborderItem>>(type: "jsonb", nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_amount_except_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_except_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_include_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_include_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_exclude_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_exclude_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount_vat_discounted = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_fee_exclude_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_fee_vat = table.Column<decimal>(type: "numeric", nullable: true),
                    total_shipping_discount = table.Column<decimal>(type: "numeric", nullable: true),
                    total_vat = table.Column<decimal>(type: "numeric", nullable: false),
                    total_discount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_items_discount = table.Column<decimal>(type: "numeric", nullable: false),
                    grand_total = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_suborder", x => x.id);
                    table.ForeignKey(
                        name: "fk_suborder_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_document",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    suborder_id = table.Column<Guid>(type: "uuid", nullable: false),
                    document_type = table.Column<int>(type: "integer", nullable: false),
                    document_no = table.Column<string>(type: "text", nullable: true),
                    ref_document_type = table.Column<int>(type: "integer", nullable: false),
                    ref_document_no = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_document", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_document_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_document_suborder_suborder_id",
                        column: x => x.suborder_id,
                        principalTable: "suborder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_order_request_id",
                table: "order",
                column: "order_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_document_order_id",
                table: "order_document",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_document_suborder_id",
                table: "order_document",
                column: "suborder_id");

            migrationBuilder.CreateIndex(
                name: "ix_suborder_order_id",
                table: "suborder",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "log_system");

            migrationBuilder.DropTable(
                name: "order_document");

            migrationBuilder.DropTable(
                name: "suborder");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "order_request");
        }
    }
}
