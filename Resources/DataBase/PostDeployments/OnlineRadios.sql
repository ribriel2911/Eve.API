GO

INSERT INTO dbo.Medias(Name, Url)
SELECT news.Name, news.Url
FROM (SELECT 'https://nowplaying.mdstrm.com/5b7dcf666253b80766f27858/576b06096457cff453000015/live/icecast.audio' AS Url, 'Futurock' AS Name UNION ALL
	  SELECT 'https://radio.relatores.com.ar/relatores.mp3', 'Relatores' UNION ALL
	  SELECT 'https://cdn2.instream.audio/:8000/stream', 'eldestaperadio') news
LEFT JOIN dbo.Medias m ON m.Url = news.Url
					  AND m.RadioId IS NULL
WHERE m.Id IS NULL

GO