using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using System;

namespace MyWebShop
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {

            SchemaBuilder.CreateTable("ProductPartRecord", table => table

                // The following method will create an "Id" column for us and set it is the primary key for the table
                .ContentPartRecord()

                // Create a column named "UnitPrice" of type "decimal"
                .Column<decimal>("UnitPrice")

                // Create the "Sku" column and specify a maximum length of 50 characters
                .Column<string>("Sku", column => column.WithLength(50))
                );

            // Return the version that this feature will be after this method completes
            return 1;
        }
        public int UpdateFrom1()
        {

            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("ProductPart", part => part
                .Attachable());

            return 2;
        }
        public int UpdateFrom2()
        {

            // Define a new content type called "ShoppingCartWidget"
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type

                // Attach the "ShoppingCartWidgetPart"
                .WithPart("ShoppingCartWidgetPart")

                // In order to turn this content type into a widget, it needs the WidgetPart
                .WithPart("WidgetPart")

                // It also needs a setting called "Stereotype" to be set to "Widget"
                .WithSetting("Stereotype", "Widget")
                );

            return 3;
        }
        public int UpdateFrom3()
        {
            // Update the ShoppingCartWidget so that it has a CommonPart attached, which is required for widgets (it's generally a good idea to have this part attached)
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type
                .WithPart("CommonPart")
            );

            return 4;
        }
        public int UpdateFrom4()
        {
            SchemaBuilder.CreateTable("CustomerPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("FirstName", c => c.WithLength(50))
                .Column<string>("LastName", c => c.WithLength(50))
                .Column<string>("Title", c => c.WithLength(10))
                .Column<DateTime>("CreatedUtc")
                );

            SchemaBuilder.CreateTable("AddressPartRecord", table => table
                .ContentPartRecord()
                .Column<int>("CustomerId")
                .Column<string>("Type", c => c.WithLength(50))
                );

            ContentDefinitionManager.AlterPartDefinition("CustomerPart", part => part
                .Attachable(false)
                );

            ContentDefinitionManager.AlterTypeDefinition("Customer", type => type
                .WithPart("CustomerPart")
                .WithPart("UserPart")
                );

            ContentDefinitionManager.AlterPartDefinition("AddressPart", part => part
                .Attachable(false)
                .WithField("Name", f => f.OfType("TextField"))
                .WithField("AddressLine1", f => f.OfType("TextField"))
                .WithField("AddressLine2", f => f.OfType("TextField"))
                .WithField("Zipcode", f => f.OfType("TextField"))
                .WithField("City", f => f.OfType("TextField"))
                .WithField("Country", f => f.OfType("TextField"))
                );

            ContentDefinitionManager.AlterTypeDefinition("Address", type => type
                .WithPart("CommonPart")
                .WithPart("AddressPart")
                );

            return 5;
        }
        public int UpdateFrom5()
        {
            SchemaBuilder.CreateTable("OrderPartRecord", t => t
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<int>("CustomerId", c => c.NotNull())
                .Column<DateTime>("CreatedAt", c => c.NotNull())
                .Column<decimal>("SubTotal", c => c.NotNull())
                .Column<decimal>("Vat", c => c.NotNull())
                .Column<string>("Status", c => c.WithLength(50).NotNull())
                .Column<string>("PaymentServiceProviderResponse", c => c.WithLength(null))
                .Column<string>("PaymentReference", c => c.WithLength(50))
                .Column<DateTime>("PaidAt", c => c.Nullable())
                .Column<DateTime>("CompletedAt", c => c.Nullable())
                .Column<DateTime>("CancelledAt", c => c.Nullable())
                );

            SchemaBuilder.CreateTable("OrderDetailPartRecord", t => t
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<int>("OrderRecord_Id", c => c.NotNull())
                .Column<int>("ProductId", c => c.NotNull())
                .Column<int>("Quantity", c => c.NotNull())
                .Column<decimal>("UnitPrice", c => c.NotNull())
                .Column<decimal>("VatRate", c => c.NotNull())
                );

            SchemaBuilder.CreateForeignKey("Order_Customer", "OrderPartRecord", new[] { "CustomerId" }, "CustomerPartRecord", new[] { "Id" });
            SchemaBuilder.CreateForeignKey("OrderDetail_Order", "OrderDetailPartRecord", new[] { "OrderRecord_Id" }, "OrderPartRecord", new[] { "Id" });
            SchemaBuilder.CreateForeignKey("OrderDetail_Product", "OrderDetailPartRecord", new[] { "ProductId" }, "ProductPartRecord", new[] { "Id" });

            return 6;
        }
        public int UpdateFrom6()
        {

            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderPart", part => part
                .Attachable());
            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderDetailPart", part => part
                .Attachable());
            return 7;
        }
        public int UpdateFrom7()
        {
            ContentDefinitionManager.AlterTypeDefinition("Order", type => type
                .WithPart("OrderPart"));
            ContentDefinitionManager.AlterTypeDefinition("OrderDetail", type => type
                .WithPart("OrderDetailPart"));

            return 8;
        }
        public int UpdateFrom8()
        {
            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderPart", part => part
                .Attachable(false));
            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderDetailPart", part => part
                .Attachable(false));

            ContentDefinitionManager.AlterTypeDefinition("Order", type => type
          .WithPart("OrderPart"));

            ContentDefinitionManager.AlterTypeDefinition("OrderDetail", type => type
                .WithPart("OrderDetailPart"));

            return 9;
        }

        public int UpdateFrom9()
        {


            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderPart", part => part
                .Attachable(false));
            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderDetailPart", part => part
                .Attachable(false));

            ContentDefinitionManager.AlterTypeDefinition("Order", type => type
         .WithPart("CommonPart")
                .WithPart("OrderPart"));

            ContentDefinitionManager.AlterTypeDefinition("OrderDetail", type => type
                .WithPart("CommonPart")
                .WithPart("OrderDetailPart"));

            return 10;
        }
        public int UpdateFrom10()
        {
            SchemaBuilder.CreateTable("OrderPartRecord", t => t
               .ContentPartRecord()
               .Column<int>("CustomerId", c => c.NotNull())
               .Column<DateTime>("CreatedAt", c => c.NotNull())
               .Column<decimal>("SubTotal", c => c.NotNull())
               .Column<decimal>("Vat", c => c.NotNull())
               .Column<string>("Status", c => c.WithLength(50).NotNull())
               .Column<string>("PaymentServiceProviderResponse", c => c.WithLength(null))
               .Column<string>("PaymentReference", c => c.WithLength(50))
               .Column<DateTime>("PaidAt", c => c.Nullable())
               .Column<DateTime>("CompletedAt", c => c.Nullable())
               .Column<DateTime>("CancelledAt", c => c.Nullable())
               );

            SchemaBuilder.CreateTable("OrderDetailPartRecord", t => t
                .ContentPartRecord()
                .Column<int>("OrderRecord_Id", c => c.NotNull())
                .Column<int>("ProductId", c => c.NotNull())
                .Column<int>("Quantity", c => c.NotNull())
                .Column<decimal>("UnitPrice", c => c.NotNull())
                .Column<decimal>("VatRate", c => c.NotNull())
                );

            SchemaBuilder.CreateForeignKey("Order_Customer", "OrderPartRecord", new[] { "CustomerId" }, "CustomerPartRecord", new[] { "Id" });
            SchemaBuilder.CreateForeignKey("OrderDetail_Order", "OrderDetailPartRecord", new[] { "OrderRecord_Id" }, "OrderPartRecord", new[] { "Id" });
            SchemaBuilder.CreateForeignKey("OrderDetail_Product", "OrderDetailPartRecord", new[] { "ProductId" }, "ProductPartRecord", new[] { "Id" });


            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderPart", part => part
                .Attachable(false));
            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("OrderDetailPart", part => part
                .Attachable(false));

            ContentDefinitionManager.AlterTypeDefinition("Order", type => type
         .WithPart("CommonPart")
                .WithPart("OrderPart"));

            ContentDefinitionManager.AlterTypeDefinition("OrderDetail", type => type
                .WithPart("CommonPart")
                .WithPart("OrderDetailPart"));

            return 11;
        }

        public int UpdateFrom11()
        {

            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type

                          // Attach the "ShoppingCartWidgetPart"
                          .WithPart("ShoppingCartWidgetPart")

                          .WithPart("CommonPart")
                          // In order to turn this content type into a widget, it needs the WidgetPart
                          .WithPart("WidgetPart")

                          // It also needs a setting called "Stereotype" to be set to "Widget"
                          .WithSetting("Stereotype", "Widget")
                          );

            return 12;
        }
    }
}