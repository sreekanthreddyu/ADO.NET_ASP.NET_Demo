-- =============================================
-- Author:		<Author,Paritosh>
-- Create date: <Create Date,25-Oct-2016>
-- Description:	<Description,SP for ADO.Net Demo Code>
-- =============================================

-- Insert and Update stored procedure for tbl_Products_PG_ADODotNetDemoCode
CREATE PROCEDURE usp_SAVE_tbl_Products_PG_ADODotNetDemoCode(
	@ProID				INT,
	@ProductName		VARCHAR(20),
	@Rate				MONEY,
	@Quantity			INT,
	@ProductID			INT OUT	
)
AS
BEGIN

	IF @ProId = 0
	BEGIN
			
			INSERT INTO tbl_Products_PG_ADODotNetDemoCode ( ProductName, Rate, Quantity)
							VALUES(@ProductName, @Rate, @Quantity)

					SET @ProductID = @@IDENTITY
 
	END
	ELSE
	BEGIN

			UPDATE tbl_Products_PG_ADODotNetDemoCode

					SET ProductName		= @ProductName,
						Rate			= @Rate,
						Quantity		= @Quantity

				WHERE ProductID = @ProId

				SET @ProductID = @ProID

	END
END

-- Delete stored procedure for tbl_Products_PG_ADODotNetDemoCode

CREATE PROCEDURE usp_DELETE_tbl_Products_PG_ADODotNetDemoCode(
	@ProID				INT
)
AS
BEGIN

DELETE FROM tbl_Products_PG_ADODotNetDemoCode WHERE ProductID=@ProID

END

-- View stored procedure for tbl_Products_PG_ADODotNetDemoCode

CREATE PROCEDURE usp_VIEW_tbl_Products_PG_ADODotNetDemoCode
AS
BEGIN

SELECT * FROM tbl_Products_PG_ADODotNetDemoCode

END

-- View by ID stored procedure for tbl_Products_PG_ADODotNetDemoCode

CREATE PROCEDURE usp_ViewByID_tbl_Products_PG_ADODotNetDemoCode(
	@ProID				INT
)
AS
BEGIN

SELECT * FROM tbl_Products_PG_ADODotNetDemoCode WHERE ProductID=@ProID

END