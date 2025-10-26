GO

BEGIN 
	SET IDENTITY_INSERT dbo.Waves ON

	INSERT INTO dbo.Waves(Id, Name)
	SELECT news.* 
	FROM (SELECT 1 AS Id, 'AM' AS Name UNION ALL
		  SELECT 2, 'FM') news
	LEFT JOIN dbo.Waves w ON w.Id = news.Id
	WHERE w.Id IS NULL

	SET IDENTITY_INSERT dbo.Waves OFF
END

GO