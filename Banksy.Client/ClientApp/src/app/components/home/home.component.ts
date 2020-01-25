import { Component, OnInit } from "@angular/core";
import { UploadService } from "src/app/services/upload.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  private fileToUpload: File;
  private showAlert: boolean;
  public amountOfMutations: number;

  constructor(private uploadService: UploadService) {}

  ngOnInit(): void {
    this.showAlert = false;
    this.fileToUpload = null;
  }

  uploadFileToActivity(files: FileList) {
    this.fileToUpload = files.item(0);
    this.uploadService.uploadFile(this.fileToUpload).subscribe(
      data => {
        this.amountOfMutations = +data;
        this.showAlert = true;
      },
      error => {
        console.log(error);
      }
    );
  }

  closeAlert(): void {
    this.showAlert = false;
  }
}
