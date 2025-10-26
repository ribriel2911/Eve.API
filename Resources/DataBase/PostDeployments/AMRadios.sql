GO

DECLARE @news AS TABLE
(
	Name VARCHAR(255) NOT NULL,
	Url VARCHAR(MAX) NOT NULL,
	Frequency DECIMAL(5,1) NULL
)

INSERT INTO @news(Url, Name, Frequency)
SELECT *
FROM (SELECT 'http://cdn.instream.audio:9288/stream' AS Url, 'Radio Madre' AS Name, 530.0 AS Frequency UNION ALL
	  SELECT 'https://streaming1.hostingmontevideo.com:7019/;', 'Radio Colonia', 550.0 UNION ALL
	  SELECT 'http://server.laradio.online:25224/live.mp3', 'Radio Argentina', 570.0 UNION ALL
	  SELECT 'http://playerservices.streamtheworld.com/api/livestream-redirect/CONTINENTAL_SC', 'Continental', 590.0 UNION ALL
	  SELECT 'https://streammax.alsolnet.com/radiorivadavia', 'Rivadavia', 630.0 UNION ALL
	  SELECT 'http://server.laradio.online:25223/live.mp3', 'Belgrano-650', 650.0 UNION ALL
	  SELECT 'http://s6.stweb.tv/radio10/live/playlist.m3u8', 'Radio 10', 710.0 UNION ALL
	  SELECT 'http://servidor.01argentina.com.ar:6358', 'Radio Rebelde', 740.0 UNION ALL
	  SELECT 'http://192.99.38.174:9342/stream', '', 750.0 UNION ALL
	  SELECT 'https://arcast.com.ar:9501/AM750.MP3', '', 750.0 UNION ALL
	  SELECT 'http://rcoop.cnwks.ws:8358', 'Cooperativa', 770.0 UNION ALL
	  SELECT 'https://buecrplb01.cienradios.com.ar/Mitre790.aac', 'Radio Mitre', 790.0 UNION ALL
	  SELECT 'http://streaming.radiolinksmedia.com:7830/;', 'Del Pueblo', 830.0 UNION ALL
	  SELECT 'http://sa.mp3.icecast.magma.edge-access.net:7200/sc_rad1', 'Radio Nacional', 870.0 UNION ALL
	  SELECT 'https://strive-sdn-lsdlive-live.akamaized.net/live_passthrough_static/amlared/playlist.m3u8', 'La Red', 910.0 UNION ALL
	  SELECT 'http://200.58.118.108:8160/stream', 'Radio Gral Belg', 950.0 UNION ALL
	  SELECT 'http://streamlky.alsolnet.com:443/radio9', 'R9 La Deportiva', 950.0 UNION ALL
	  SELECT 'http://streaming.radiolinksmedia.com:7890/;', 'Radio Génesis', 970.0 UNION ALL
	  SELECT 'https://streamten.alsolnet.com/la990', 'la990', 990.0 UNION ALL
	  SELECT 'http://181.119.157.98:8000/amdelplata.mp3', 'Del Plata', 1030.0 UNION ALL
	  SELECT 'http://nnvserver.com:8032/stream', 'Güemes', 1050.0 UNION ALL
	  SELECT 'http://66.70.255.8:9368/baires?type=.mp3', 'El Mundo', 1070.0 UNION ALL
	  SELECT 'http://radios.argentina.fm:1110/stream', 'De la ciudad', 1110.0 UNION ALL
	  SELECT 'http://server.ohradio.com.ar:9344/;', 'Radio La Luna', 1140.0 UNION ALL
	  SELECT 'rtmp://server2.stweb.tv:1935/america/live_128', 'Radio América', 1190.0 UNION ALL
	  SELECT 'http://ample-zeno-09.radiojar.com/uv3vkhw2qvduv', 'Eco medios', 1220.0) news

INSERT INTO dbo.Radios(Frequency, WaveId)
SELECT DISTINCT n.Frequency, 1 AS WaveId
FROM @news n
LEFT JOIN dbo.Radios r ON r.WaveId = 1 
					  AND r.Frequency = n.Frequency
WHERE r.Id IS NULL

INSERT INTO dbo.Medias(Url, Name, RadioId)
SELECT DISTINCT n.Url, n.Name, r.Id  
FROM @news n
INNER JOIN dbo.Radios r ON r.Frequency = n.Frequency
						AND r.WaveId = 1
LEFT JOIN dbo.Medias m ON m.Url = n.Url
WHERE m.Id IS NULL

GO