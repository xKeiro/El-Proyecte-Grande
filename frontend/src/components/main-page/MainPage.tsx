const styles = {
    container: {
      width: 300,
      height: 1300,
      margin: '50px auto',
      backgroundColor: "orange",
      display: "flex",
      flexDirection: "column",
      justifyContent: 'center',
      alignItems: 'center',
      fontWeight: "bold",
    },
  } as const;


const MainPage = () => {
    return (
        <h1 style={styles.container}> MAINPAGE Placeholder</h1>
    );
};

export default MainPage;