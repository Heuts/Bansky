import { Injectable, Inject } from "@angular/core";
import { API_BASE_URL } from "../injection-tokens/api-base-url-token";
import { HttpClient, HttpRequest, HttpEventType } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class UploadService {
  private baseUrl: string;
  public progress: number;
  public message: string;

  constructor(
    private http: HttpClient,
    @Inject(API_BASE_URL) private apiServerUrl: string
  ) {
    this.baseUrl = `${apiServerUrl}/api/import`;
  }

  uploadFile(file: File) {
    const formData = new FormData();
    formData.append(file.name, file);

    console.log(formData);
    return this.http.post(`${this.baseUrl}`, formData, {
      responseType: "text"
    });
  }
}
