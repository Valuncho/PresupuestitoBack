using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresupuestitoBack.Migrations
{
    /// <inheritdoc />
    public partial class haber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CategoryModel = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    IdCost = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.IdCost);
                });

            migrationBuilder.CreateTable(
                name: "FixedCost",
                columns: table => new
                {
                    IdFixedCost = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    WorkingDays = table.Column<int>(type: "INT", nullable: false),
                    HoursWorked = table.Column<int>(type: "INT", nullable: false),
                    DateCharged = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedCost", x => x.IdFixedCost);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    DNI = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    CUIT = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryMaterialId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CategoryId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryMaterialId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    OPersonIdPerson = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Clients_People_OPersonIdPerson",
                        column: x => x.OPersonIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    OPersonIdPerson = table.Column<int>(type: "INT", nullable: false),
                    Salary = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employees_People_OPersonIdPerson",
                        column: x => x.OPersonIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    IdSupplier = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    OPersonIdPerson = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.IdSupplier);
                    table.ForeignKey(
                        name: "FK_Suppliers_People_OPersonIdPerson",
                        column: x => x.OPersonIdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    MaterialDescription = table.Column<string>(type: "NVARCHAR(400)", nullable: false),
                    MaterialColor = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    MaterialBrand = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    MaterialMeasure = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    MaterialUnitMeasure = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    OSubcategorySubCategoryMaterialId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_SubCategories_OSubcategorySubCategoryMaterialId",
                        column: x => x.OSubcategorySubCategoryMaterialId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientsHistorys",
                columns: table => new
                {
                    IdClientHistory = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsHistorys", x => x.IdClientHistory);
                    table.ForeignKey(
                        name: "FK_ClientsHistorys_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHistories",
                columns: table => new
                {
                    IdEmployeeHistory = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHistories", x => x.IdEmployeeHistory);
                    table.ForeignKey(
                        name: "FK_EmployeeHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierHistories",
                columns: table => new
                {
                    SupplierHistoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuplierId = table.Column<int>(type: "int", nullable: false),
                    OsupplierIdSupplier = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierHistories", x => x.SupplierHistoryId);
                    table.ForeignKey(
                        name: "FK_SupplierHistories_Suppliers_OsupplierIdSupplier",
                        column: x => x.OsupplierIdSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "IdSupplier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    IdBudget = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DescriptionBudget = table.Column<string>(type: "NVARCHAR(400)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ClientHistoryId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.IdBudget);
                    table.ForeignKey(
                        name: "FK_Budgets_ClientsHistorys_ClientHistoryId",
                        column: x => x.ClientHistoryId,
                        principalTable: "ClientsHistorys",
                        principalColumn: "IdClientHistory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    IdInvoice = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsPaid = table.Column<bool>(type: "BIT", nullable: false),
                    SuplierHistoryId = table.Column<int>(type: "int", nullable: false),
                    OSupplierHistorySupplierHistoryId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.IdInvoice);
                    table.ForeignKey(
                        name: "FK_Invoices_SupplierHistories_OSupplierHistorySupplierHistoryId",
                        column: x => x.OSupplierHistorySupplierHistoryId,
                        principalTable: "SupplierHistories",
                        principalColumn: "SupplierHistoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    IdWork = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimatedHoursWorked = table.Column<int>(type: "INT", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "DATE", nullable: false),
                    CostPrice = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    BudgetId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.IdWork);
                    table.ForeignKey(
                        name: "FK_Works_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "IdBudget",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicesItems",
                columns: table => new
                {
                    IdInvoiceItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMaterial = table.Column<int>(type: "int", nullable: false),
                    OMaterialMaterialId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesItems", x => x.IdInvoiceItem);
                    table.ForeignKey(
                        name: "FK_InvoicesItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "IdInvoice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicesItems_Materials_OMaterialMaterialId",
                        column: x => x.OMaterialMaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DescriptionPayment = table.Column<string>(type: "VARCHAR(400)", nullable: false),
                    IdInvoice = table.Column<int>(type: "int", nullable: false),
                    OInvoiceIdInvoice = table.Column<int>(type: "INT", nullable: true),
                    IdBudget = table.Column<int>(type: "int", nullable: false),
                    OBudgetIdBudget = table.Column<int>(type: "INT", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Budgets_OBudgetIdBudget",
                        column: x => x.OBudgetIdBudget,
                        principalTable: "Budgets",
                        principalColumn: "IdBudget");
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_OInvoiceIdInvoice",
                        column: x => x.OInvoiceIdInvoice,
                        principalTable: "Invoices",
                        principalColumn: "IdInvoice");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMaterial = table.Column<int>(type: "int", nullable: false),
                    OMaterialMaterialId = table.Column<int>(type: "INT", nullable: false),
                    IdWork = table.Column<int>(type: "int", nullable: false),
                    OWorkIdWork = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Items_Materials_OMaterialMaterialId",
                        column: x => x.OMaterialMaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Works_OWorkIdWork",
                        column: x => x.OWorkIdWork,
                        principalTable: "Works",
                        principalColumn: "IdWork",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsBudget",
                columns: table => new
                {
                    PaymentBudgetId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "INT", nullable: false),
                    BudgetId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsBudget", x => x.PaymentBudgetId);
                    table.ForeignKey(
                        name: "FK_PaymentsBudget_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "IdBudget",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentsBudget_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsInvoice",
                columns: table => new
                {
                    PaymentInvoiceId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "INT", nullable: false),
                    InvoiceId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsInvoice", x => x.PaymentInvoiceId);
                    table.ForeignKey(
                        name: "FK_PaymentsInvoice_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "IdInvoice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentsInvoice_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    IdSalary = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    BillDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdPayments = table.Column<int>(type: "int", nullable: false),
                    OPaymentPaymentId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.IdSalary);
                    table.ForeignKey(
                        name: "FK_Salaries_Payments_OPaymentPaymentId",
                        column: x => x.OPaymentPaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsSalary",
                columns: table => new
                {
                    PaymentSalaryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "INT", nullable: false),
                    SalaryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsSalary", x => x.PaymentSalaryId);
                    table.ForeignKey(
                        name: "FK_PaymentsSalary_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PaymentsSalary_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "IdSalary",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_ClientHistoryId",
                table: "Budgets",
                column: "ClientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_OPersonIdPerson",
                table: "Clients",
                column: "OPersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsHistorys_ClientId",
                table: "ClientsHistorys",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistories_EmployeeId",
                table: "EmployeeHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OPersonIdPerson",
                table: "Employees",
                column: "OPersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OSupplierHistorySupplierHistoryId",
                table: "Invoices",
                column: "OSupplierHistorySupplierHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesItems_InvoiceId",
                table: "InvoicesItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesItems_OMaterialMaterialId",
                table: "InvoicesItems",
                column: "OMaterialMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OMaterialMaterialId",
                table: "Items",
                column: "OMaterialMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OWorkIdWork",
                table: "Items",
                column: "OWorkIdWork");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_OSubcategorySubCategoryMaterialId",
                table: "Materials",
                column: "OSubcategorySubCategoryMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OBudgetIdBudget",
                table: "Payments",
                column: "OBudgetIdBudget");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OInvoiceIdInvoice",
                table: "Payments",
                column: "OInvoiceIdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsBudget_BudgetId",
                table: "PaymentsBudget",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsBudget_PaymentId",
                table: "PaymentsBudget",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsInvoice_InvoiceId",
                table: "PaymentsInvoice",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsInvoice_PaymentId",
                table: "PaymentsInvoice",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsSalary_PaymentId",
                table: "PaymentsSalary",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsSalary_SalaryId",
                table: "PaymentsSalary",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_OPaymentPaymentId",
                table: "Salaries",
                column: "OPaymentPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierHistories_OsupplierIdSupplier",
                table: "SupplierHistories",
                column: "OsupplierIdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_OPersonIdPerson",
                table: "Suppliers",
                column: "OPersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Works_BudgetId",
                table: "Works",
                column: "BudgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "EmployeeHistories");

            migrationBuilder.DropTable(
                name: "FixedCost");

            migrationBuilder.DropTable(
                name: "InvoicesItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PaymentsBudget");

            migrationBuilder.DropTable(
                name: "PaymentsInvoice");

            migrationBuilder.DropTable(
                name: "PaymentsSalary");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ClientsHistorys");

            migrationBuilder.DropTable(
                name: "SupplierHistories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
