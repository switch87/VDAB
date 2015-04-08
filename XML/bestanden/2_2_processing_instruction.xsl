<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions">
<xsl:template match="/">
	<html>
		<head>
			<title>Voorbeeld Processing Instruction</title>
		</head>
		<body>
			<h1><xsl:value-of  select="/naam/voornaam"></xsl:value-of> <xsl:value-of  select="/naam/familienaam"></xsl:value-of></h1>
			<h2><xsl:value-of  select="/naam/gemeente"></xsl:value-of></h2>
		</body>
	</html>
</xsl:template>
</xsl:stylesheet>
