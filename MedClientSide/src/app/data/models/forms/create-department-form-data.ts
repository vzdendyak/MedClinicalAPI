import {Address} from '../address';
import {Schedule} from '../schedule';
import {Service} from '../service';

export class CreateDepartmentFormData {
  addresses: Address[];
  schedules: Schedule[];
  services: Service[];
}
