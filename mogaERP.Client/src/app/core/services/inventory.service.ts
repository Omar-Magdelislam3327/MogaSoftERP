import { Injectable, signal } from '@angular/core';
import { environment } from '../../../env/environment';
import { HttpClient } from '@angular/common/http';
import { PagedResult, ReciptPermission } from '../models/inventory/reciptPermissions';
import { Observable, of } from 'rxjs';
import { catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
 private baseUrl = `${environment.baseUrl}`;

  // ======== Signals Usage ========
  reciptPermissions = signal<ReciptPermission[]>([]);
  exchangePermissions = signal<any[]>([]);
  exchangeRequests = signal<any[]>([]);
  loading = signal<boolean>(false);
  error = signal<string | null>(null);

  constructor(private http: HttpClient) {}
  // ============================================== Recipt Permissions ============================================== 
  getReciptPermissions(
    pageNumber: number,
    pageSize: number,
    searchTerm: string = '',
    sortDescending: boolean = true
  ): Observable<PagedResult<ReciptPermission>> {
    this.loading.set(true);
    const url = `${this.baseUrl}ReceiptPermissions?PageNumber=${pageNumber}&PageSize=${pageSize}&SearchTerm=${searchTerm}&SortDescending=${sortDescending}`;
    
    return this.http.get<PagedResult<ReciptPermission>>(url).pipe(
      catchError(err => {
        console.error('Error fetching recipt permissions', err);
        return of({ data: [], totalCount: 0 });
      })
    );
  }
  
  getReciptPermissionById(id: number) {
    return this.http.get<ReciptPermission>(`${this.baseUrl}ReceiptPermissions/${id}`);
  }
  addReciptPermission(reciptPermission: ReciptPermission) {
    return this.http.post<ReciptPermission>(`${this.baseUrl}ReceiptPermissions`, reciptPermission);
  }
  updateReciptPermission(id: number, reciptPermission: ReciptPermission) {
    return this.http.put<ReciptPermission>(`${this.baseUrl}ReceiptPermissions/${id}`, reciptPermission);
  }
  deleteReciptPermission(id: number) {
    return this.http.delete<ReciptPermission>(`${this.baseUrl}ReceiptPermissions/${id}`);
  }
  // ============================================== End Recipt Permissions ============================================== 
}
