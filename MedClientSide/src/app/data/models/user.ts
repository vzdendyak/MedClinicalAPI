import {Department} from './department';
import {Record} from './record';

export class User {
  public id: string;
  public userName: string;
  public firstName: string;
  public lastName: string;
  public email: string;
  public phoneNumber: string;
  public age: number;
  public departmentId: number;
  public department: Department;
  public records: Record[];
}
