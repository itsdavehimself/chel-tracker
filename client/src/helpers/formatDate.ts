import { format } from 'date-fns';

const formatDate = (date: string) => {
    return format(date, 'LLLL do, yyyy');
};

export default formatDate;
