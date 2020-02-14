import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { API_BASE_URL } from "../injection-tokens/api-base-url-token";
import { Observable } from "rxjs";
import { MutationDto } from "../dtos/mutation.dto";

@Injectable({
  providedIn: "root"
})
export class MutationService {
  private baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject(API_BASE_URL) private apiServerUrl: string
  ) {
    this.baseUrl = `${apiServerUrl}/api/mutation`;
  }

  getMutation(mutationId: number): Observable<MutationDto> {
    return this.http.get<MutationDto>(`${this.baseUrl}/` + mutationId);
  }
  
  getMutationsByPageAndSize(page: number, size: number): Observable<MutationDto[]> {
    return this.http.get<MutationDto[]>(`${this.baseUrl}/page/` + page + `/` + size);
  }

  getTotalMutations() {
    return this.http.get<number>(`${this.baseUrl}/total`);
  }
}
