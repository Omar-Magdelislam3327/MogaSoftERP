import { Component, inject } from '@angular/core';
import { SysSettingsService } from '../../../../core/services/sys-settings.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-main-groups',
  templateUrl: './main-groups.component.html',
  styleUrl: './main-groups.component.css',
  providers: [MessageService]
})
export class MainGroupsComponent {
  private service = inject(SysSettingsService);
  private messageService = inject(MessageService);
  mainGroups = this.service.mainGroups;
  loading = this.service.loading;
  error = this.service.error;

  ngOnInit(): void {
    this.loadMainGroups()
  }

  loadMainGroups() {
    this.service.getAllMainGroups().subscribe({
      next: () => {
        console.log(this.mainGroups());
        
      },
      error: () => {
        this.messageService.add({ severity: 'error', summary: 'خطأ', detail: 'فشل في تحميل المجموعات الرئيسية' });
      }
    });
  }

  addMainGroup() {
    
  }

  editMainGroup(id: number) {
    
  }

  deleteMainGroup(id: number) {
    this.service.deleteMainGroup(id).subscribe({
      next: () => {
        this.messageService.add({ severity: 'warn', summary: 'تم', detail: 'تم حذف المجموعة' });
      },
      error: () => {
        this.messageService.add({ severity: 'error', summary: 'خطأ', detail: 'فشل في حذف المجموعة' });
      }
    });
  }
}
