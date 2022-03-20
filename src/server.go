package main

import (
	"github.com/gin-gonic/gin"
)

func main() {
	router := gin.Default()
	router.POST("/downloadFile", DownloadFileController)
	router.POST("/uploadFIle", UploadFileController)
	router.POST("/getMetadata", GetFileMetadata)

	router.Run("localhost:8080")
}
