const ConnectedUsers = ({ users }) => {
    return(
    <div className='user-list'>
        <h4>Connected Users</h4>
        {users.map((u, idx) => <h5 key={idx}>{u.username}</h5>)}
    </div>);
};

export default ConnectedUsers;