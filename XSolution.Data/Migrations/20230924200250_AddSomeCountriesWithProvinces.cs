using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XSolution.Data.Migrations
{
    public partial class AddSomeCountriesWithProvinces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var countryCommandSet = new List<string>();

            countryCommandSet.Add(@"                
                DO $$ 
                    DECLARE 
	                    countryId INT;
                BEGIN
	                INSERT INTO ""Countries"" (""Name"", ""IsAvailable"") VALUES ('Bulgaria', true)
                    RETURNING ""Id"" INTO countryId;
	                INSERT INTO ""CountryProvinces"" (""CountryId"", ""ProvinceName"", ""IsAvailable"") 
		            VALUES 
			            (countryId, 'Blagoevgrad', true),
			            (countryId, 'Burgas', true),
			            (countryId, 'Dobrich', true),
			            (countryId, 'Gabrovo', true),
			            (countryId, 'Haskovo', true),
			            (countryId, 'Kardzhali', true);
	
                END $$;"
            );

            countryCommandSet.Add(@"                
                DO $$ 
                    DECLARE 
	                    countryId INT;
                BEGIN
	                INSERT INTO ""Countries"" (""Name"", ""IsAvailable"") VALUES ('Canada', true)
                    RETURNING ""Id"" INTO countryId;
	                INSERT INTO ""CountryProvinces"" (""CountryId"", ""ProvinceName"", ""IsAvailable"") 
		            VALUES 
			            (countryId, 'Ontario', true),
			            (countryId, 'Quebec', true),
			            (countryId, 'Nova Scotia', true),
			            (countryId, 'New Brunswick', true),
			            (countryId, 'Manitoba', true),
			            (countryId, 'British Columbia', true);
	
                END $$;"
            );

            countryCommandSet.Add(@"                
                DO $$ 
                    DECLARE 
	                    countryId INT;
                BEGIN
	                INSERT INTO ""Countries"" (""Name"", ""IsAvailable"") VALUES ('Cuba', true)
                    RETURNING ""Id"" INTO countryId;
	                INSERT INTO ""CountryProvinces"" (""CountryId"", ""ProvinceName"", ""IsAvailable"") 
		            VALUES 
			            (countryId, 'Pinar del Río', true),
			            (countryId, 'Artemisa', true),
			            (countryId, 'La Habana', true),
			            (countryId, 'Matanzas', true),
			            (countryId, 'Cienfuegos', true),
			            (countryId, 'Villa Clara', true);
	
                END $$;"
 );

            foreach ( var countryCommand in countryCommandSet) 
            {
                migrationBuilder.Sql(countryCommand);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
