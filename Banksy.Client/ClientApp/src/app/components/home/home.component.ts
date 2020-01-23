import { Component } from "@angular/core";
import { UploadService } from "src/app/services/upload.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html"
})
export class HomeComponent {
  fileToUpload: File = null;

  constructor(private uploadService: UploadService) {}

  uploadFileToActivity(files: FileList) {
    this.fileToUpload = files.item(0);
    this.uploadService.uploadFile(this.fileToUpload).subscribe(
      data => {
        // do something, if upload success
      },
      error => {
        console.log(error);
      }
    );
  }
}
