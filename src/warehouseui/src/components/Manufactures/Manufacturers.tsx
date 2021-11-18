import { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Manufacturer } from '../../Types/types';


const ManufacturersList = () => {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState<Manufacturer[]>([]);
    let history = useHistory();

    const fetchFromServer = () => {
        fetch('http://localhost:5000/manufactures')
        .then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((result) => {
            setIsLoaded(true);
            setItems(result);
        }).catch((error) => {
            setIsLoaded(true);
            setError(error);
        });
    };

    const redirect = (id: number) => {
        history.push('/editManufacturer/' + id)
    };

    const deleteGood = (id: number) => {
        fetch('http://localhost:5000/manufactures/' + id, {method: 'DELETE'})
        .then((response) => {
            if (!response.ok) {
                throw new Error('Something went wrong');
            }
        })
        .then((result) => {
            fetchFromServer();

        }).catch((error) => {
            setIsLoaded(true);
            setError(error.message);
        });
    };

    useEffect(() => {
        fetchFromServer();
    }, []);

    const AddGood = () => {
        history.push('/addManufacturer');
    };

    if (error) {
        return <div>Error: {error}</div>;
    } else if (!isLoaded) {
        return <div>Loading...</div>;
    } else {
        return (
            <div>
                <button onClick={() => AddGood()}>Додати</button>
                <table style={{"borderWidth":"1px", 'borderColor':"#aaaaaa", 'borderStyle':'solid'}}>
                    <thead>
                        <tr>
                            <td>Виробник</td>
                            <td>Країна</td>
                            <td></td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                    {items.map((item, index) => {     
                        return (
                            <tr key={index}>
                                <td>{item?.name}</td>
                                <td>{item?.country?.name}</td>
                                <td><button onClick={() => redirect(item.id)}>Редагувати</button></td>
                                <td><button onClick={() => deleteGood(item.id)}>Видалити</button></td>
                            </tr>
                        ) 
                    })}
                    </tbody>
                </table>
            </div>
        );
    }

}

export default ManufacturersList;