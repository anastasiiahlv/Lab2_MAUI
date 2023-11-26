<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output
		method="html"></xsl:output>
	<xsl:template match="/">
		<html>
			<body>
				<table border = "1">
					<TR>
						<th>AuthorName</th>
						<th>Name</th>
						<th>Faculty</th>
						<th>Department</th>
						<th>Type</th>
						<th>CreationDate</th>
					</TR>
					<xsl:for-each select = "MaterialsDataBase/Material">
						<tr>
							<td>
								<xsl:value-of select ="@AuthorName"/>
							</td>
							<td>
								<xsl:value-of select ="@Name"/>
							</td>
							<td>
								<xsl:value-of select ="@Faculty"/>
							</td>
							<td>
								<xsl:value-of select ="@Department"/>
							</td>
							<td>
								<xsl:value-of select ="@Type"/>
							</td>
							<td>
								<xsl:value-of select ="@CreationDate"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
