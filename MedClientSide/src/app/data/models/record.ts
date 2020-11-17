import {Service} from './service';

export class Record {
  id: number;
  doctorId: string;
  patientId: string;
  dateOfMeeting: number;
  dateOfRecord: number;
  serviceId: number;
  service: Service;
}
