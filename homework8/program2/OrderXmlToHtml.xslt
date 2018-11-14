<?xml version="1.0" encoding="utf-8" ?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <xsl:template match="/ArrayOfOrder">

    <html>

      <head>

        <title>Order System</title>

      </head>

      <body>

        <h1>Order System</h1>

        <table border="1">

          <tr>

            <th>订单号</th>

            <th>客户名称</th>

            <th>客户电话</th>

            <th>订单总金额</th>

          </tr>

          <xsl:for-each select="Order">

            <tr>

              <td>

                <xsl:value-of select="OrderNum" />

              </td>

              <td>

                <xsl:value-of select="ClientName" />

              </td>

              <td>

                <xsl:value-of select="ClinetPhoneNumber" />

              </td>

              <td>

                <xsl:value-of select="AllPrice" />

              </td>

            </tr>

          </xsl:for-each>

        </table>











        <xsl:for-each select="Order">

          <table border="1">

            <tr>

              <th>

                <xsl:value-of select="OrderNum" />

              </th>

            </tr>

            <tr>

              <th>商品名称</th>

              <th>商品单价</th>

              <th>商品数量</th>

            </tr>

            <xsl:for-each select="myOrderDetails">

              <xsl:for-each select="OrderDetails">

                <tr>

                  <xsl:for-each select="MyProduct">

                    <td>

                      <xsl:value-of select="ProductName" />

                    </td>

                    <td>

                      <xsl:value-of select="ProductPrice" />

                    </td>

                  </xsl:for-each>

                  <td>

                    <xsl:value-of select="ProductNum" />

                  </td>

                </tr>

              </xsl:for-each>

            </xsl:for-each>





          </table>

        </xsl:for-each>



      </body>

    </html>

  </xsl:template>

</xsl:stylesheet>
