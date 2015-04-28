osql -E -S .\sql2008r2 -Q"backup database sinapsis2 to disk='c:\sistemas\sinapsis.bak' with init"
copy c:\sistemas\sinapsis.bak *.*