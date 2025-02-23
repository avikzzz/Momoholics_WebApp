
export interface IUser {
  custId?: number,
  custName: string,
  gender: string,
  age: number,
  custAddress: string,
  phoneNumber: number,
  emailId: string,
  password:string
  balance?: number,
  createdDate?: Date
}
