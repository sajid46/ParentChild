<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" indent="yes"/>
  
    <xsl:template match="/Students">
      <h1>
      <xsl:value-of select="SchoolName"/>
      </h1>
        <xsl:for-each select="Student">

          <xsl:value-of select="Name"/>
          <xsl:text disable-output-escaping="yes"><![CDATA[&nbsp;&nbsp;&nbsp;&nbsp;]]></xsl:text>
          <xsl:value-of select="Country"/>
          <br></br>
          <h4>
            Scores
          </h4>
          
          <xsl:for-each select="Scores">
            <xsl:value-of select="Score1"/>
            <br></br>
            <xsl:value-of select="Score2"/>
            <br></br>
            <xsl:value-of select="Score3"/>
            <br></br>
          </xsl:for-each>

          <hr></hr>
          
        </xsl:for-each>
      

    </xsl:template>
</xsl:stylesheet>
