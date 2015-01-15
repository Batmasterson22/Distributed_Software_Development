<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>
			<body>
				<h1>The Persons</h1>
				<table border="2" style="width:300px">
					<tr bgcolor="yellow">
						<td><b>First Name</b></td>
            <td><b>Last Name</b></td>
						<td><b>Id</b></td>
            <td><b>Password</b></td>
						<td><b>Work</b></td>
            <td><b>Cell</b></td>
						<td><b>Category</b></td>
					</tr>
					<xsl:for-each select="Persons/Person">
						<xsl:sort select="Name/Last" />
						<tr style="font-size: 10pt; font-family: verdana">
							<td><xsl:value-of select="Name/First"/></td>
              <td><xsl:value-of select="Name/Last"/></td>
							<td><xsl:value-of select="Credential/Id"/></td>
              <td><xsl:value-of select="Credential/Password"/></td>
							<td><xsl:value-of select="Phone/Work"/></td>
              <td><xsl:value-of select="Phone/Cell"/></td>
							<td><xsl:value-of select="Categpry"/></td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>