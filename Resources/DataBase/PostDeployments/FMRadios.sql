DECLARE @news AS TABLE
(
	Name VARCHAR(255) NOT NULL,
	Url VARCHAR(MAX) NOT NULL,
	Frequency DECIMAL(5,1) NULL
)

INSERT INTO @news(Url, Name, Frequency)
SELECT *
FROM (SELECT 'http://vivo.fmlatribu.com:8000/latribu.mp3' AS Url, 'La Tribu' AS Name, 88.7 AS Frequency UNION ALL
	  SELECT 'http://vivo.radioam750.com.ar/vivofm.mp3', 'Malena', 89.1 UNION ALL
	  SELECT 'http://14073.live.streamtheworld.com/ARPEGGIOAAC', 'Arpeggio', 89.5 UNION ALL
	  SELECT 'http://server6.stweb.tv:1935/rcvos/live/playlist.m3u8', 'Radio con vos', 89.9 UNION ALL
	  SELECT 'http://208.98.41.72:9304', 'La Boca', 90.1 UNION ALL
	  SELECT 'https://cdn.instream.audio/:9069/stream', 'Delta', 90.3 UNION ALL
	  SELECT 'http://prepublish.f.qaotic.net/a02/ngrp:Vorterix_radio1_high-20057_all/Playlist.m3u8', 'Vorterix', 92.1 UNION ALL
	  SELECT 'http://147.135.11.82:9904/;', 'Vorterix', 92.1 UNION ALL
	  SELECT 'http://209.95.35.49:7240/Stream', 'Zero', 92.5 UNION ALL
	  SELECT 'http://radios.argentina.fm:9270/stream', 'La 2x4', 92.7 UNION ALL
	  SELECT 'http://streaming.radiolinksmedia.com:8252/;stream', 'Late', 93.1 UNION ALL
	  SELECT 'http://sa.mp3.icecast.magma.edge-access.net:7200/sc_rad39', 'Nacional Rock', 93.7 UNION ALL
	  SELECT 'https://edge-np.cdn.mdstrm.com/5a9ee26311c043ae48e40bcd.mp3', 'RadioDisney', 94.3 UNION ALL
	  SELECT 'http://mp3.metroaudio1.stream.avstreaming.net:7200/metro', 'Metro', 95.1 UNION ALL
	  SELECT 'http://servidor.ilive.com.ar:9330/;', 'Concepto', 95.5 UNION ALL
	  SELECT 'http://play-rockandpop.cdn.sion.com:1935/rockandpop/audioweb/playlist.m3u8', 'Rock & Pop', 95.9 UNION ALL
	  SELECT 'http://sa.mp3.icecast.magma.edge-access.net:7200/sc_rad37', 'Nacional Clásica', 96.7 UNION ALL
	  SELECT 'http://18543.live.streamtheworld.com/MUCHARADIO_SC', 'Mucha radio', 97.1 UNION ALL
	  SELECT 'http://vale.stweb.tv:1935/vale/live/playlist.m3u8', 'Vale', 97.5 UNION ALL
	  SELECT 'https://usa5.fastcast4u.com/proxy/radiocultura', 'Cultura', 97.9 UNION ALL
	  SELECT 'https://server1.stweb.tv/mega983/live/chunks.m3u8', 'Mega', 98.3 UNION ALL
	  SELECT 'http://sa.mp3.icecast.magma.edge-access.net:7200/sc_rad38', 'Nacional Folklorica', 98.7 UNION ALL
	  SELECT 'http://retransmisorasenelpais.cienradios.com.ar:8000/la100.aac', 'La 100', 99.9 UNION ALL
	  SELECT 'https://blue.secure2.footprint.net/egress/bhandler/streamroot_lsd2latam/blue/chunklist_b98304.m3u8', 'Blue', 100.7 UNION ALL
	  SELECT 'http://streaming.latina101.com.ar:8080/RadioLatina', 'Latina', 101.1 UNION ALL
	  SELECT 'https://s8.stweb.tv/popradio/live/playlist.m3u8', 'Pop', 101.5 UNION ALL
	  SELECT 'http://server4.stweb.tv:1935/lapatriada/live/playlist.m3u8', 'La patriada', 102.1 UNION ALL
	  SELECT 'http://playerservices.streamtheworld.com/api/livestream-redirect/ASPENAAC', 'Aspen', 102.3 UNION ALL
	  SELECT 'http://209.95.35.49:7013/live', 'Radio Uno', 103.1 UNION ALL
	  SELECT 'http://streamall.alsolnet.com:443/klimaxok', 'Klimax', 103.5 UNION ALL
	  SELECT 'http://streamall.alsolnet.com:443/fmsonidohd?type=.flv', 'Sonido', 103.5 UNION ALL
	  SELECT 'http://s11.stweb.tv/one/live/playlist.m3u8', 'One', 103.7 UNION ALL
	  SELECT 'http://14933.live.streamtheworld.com/RQPAAC', 'RQP', 104.3 UNION ALL
	  SELECT 'http://playerservices.streamtheworld.com/api/livestream-redirect/LOS40_ARGENTINAAAC', 'Los 40', 105.5 UNION ALL
	  SELECT 'http://108.59.9.147/proxy/arvlyxui', 'Milenium', 106.7 UNION ALL
	  SELECT 'http://edge.espn.cdn.abacast.net/espn-deportesmp3-48', 'ESPN', 107.9) news

INSERT INTO dbo.Radios(Frequency, WaveId)
SELECT DISTINCT n.Frequency, 2 AS WaveId
FROM @news n
LEFT JOIN dbo.Radios r ON r.WaveId = 2 
					  AND r.Frequency = n.Frequency
WHERE r.Id IS NULL

INSERT INTO dbo.Medias(Url, Name, RadioId)
SELECT DISTINCT n.Url, n.Name, r.Id  
FROM @news n
INNER JOIN dbo.Radios r ON r.Frequency = n.Frequency
						AND r.WaveId = 2
LEFT JOIN dbo.Medias m ON m.Url = n.Url
WHERE m.Id IS NULL

GO