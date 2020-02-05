export interface MutationDto {
    id: number;
    date: Date;
    name: string;
    accountNumber: string;
    contraAccount: string;
    code: string;
    debitCredit: string;
    amount: number;
    mutationType: string;
    description: string;
    categoryId: number;
  }
