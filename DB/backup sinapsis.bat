osql -E -S .\sqlexpress -Q"backup database sinapsis2 to disk='c:\sistemas\sinapsis.bak' with init"
osql -E -S .\sqlexpress -Q"backup database gis to disk='c:\sistemas\gis.bak' with init"

copy c:\sistemas\sinapsis.bak *.*
copy c:\sistemas\GIS.bak *.*
pause