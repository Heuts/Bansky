import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../injection-tokens/api-base-url-token';
import { Observable } from 'rxjs';
import { MutationDTO } from '../dtos/mutation.dto';

@Injectable({
  providedIn: 'root'
})
export class MutationService {
  private baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject(API_BASE_URL) private apiServerUrl: string
  ) {
    this.baseUrl = `${apiServerUrl}/api/mutation`;
  }

  getAllMutations(): Observable<MutationDTO[]> {
    return this.http.get<MutationDTO[]>(`${this.baseUrl}/all`);
  }
}
