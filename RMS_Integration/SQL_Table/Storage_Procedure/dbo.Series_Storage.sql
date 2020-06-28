CREATE PROCEDURE [dbo].[Series_Storage]
	@SeriesNo INT,
	@XaxisAccel NCHAR(5),
	@YaxisAccel NCHAR(5),
	@Temp NCHAR(5)
AS
	SELECT * FROM AccelAlz WHERE XaxisAccel=@XaxisAccel AND YaxisAccel=@YaxisAccel AND Temp=@Temp
RETURN
