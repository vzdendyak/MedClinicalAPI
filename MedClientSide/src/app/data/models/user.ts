import {Department} from './department';

export class User {
  public id: string;
  public userName: string;
  public firstName: string;
  public lastName: string;
  public email: string;
  public departmentId: number;
  public department: Department;
}
