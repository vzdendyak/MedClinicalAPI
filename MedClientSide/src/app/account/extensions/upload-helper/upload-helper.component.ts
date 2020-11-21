import {Component, OnInit, Output} from '@angular/core';
import {HttpClient, HttpEventType} from '@angular/common/http';
import {EventEmitter} from '@angular/core';

@Component({
  selector: 'app-upload-helper',
  templateUrl: './upload-helper.component.html',
  styleUrls: ['./upload-helper.component.scss']
})
export class UploadHelperComponent implements OnInit {
  public progress: number;
  public message: string;
  @Output() uploadFinished = new EventEmitter();

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    const fileToUpload = files[0] as File;
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    formData.append('user', localStorage.getItem('uId'));
    this.http.post('https://localhost:5001/api/account/avatar', formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = 'Завантажено. Оновіть сторінку, будь ласка!';
          console.log('uploaded');
          this.uploadFinished.emit(event.body);
        }
      });
  }

}
