using PureMVCContent.Controller;
using PureMVCContent.Model;

public class MyFacade : PureMVC.Patterns.Facade
{
    public const string OTHER_DATA_UPDATED = "other_data_updated";
    public const string PLAYER_REWARD_UPDATED = "player_reward_updated";
    public const string EXIT = "exit";
    public const string PLAY = "play";
    public const string START_UP = "start_up";
    public const string RESET_TRIES = "reset_tries";
    public const string SHOW_LEADERS = "show_leaders";
    public const string LEADER_ADDED = "leader_added";
    public const string LEADERS_CLEARED = "leaders_cleared";
    public const string INIT_LEVELS = "init_levels";
    public const string ENEMY_DESTROYED = "enemy_destroyed";
    public const string LEVEL_DONE = "level_done";
    public const string GAME_IS_DONE = "game_is_done";
    public const string PLAY_NEXT_LEVEL = "play_next_level";
    public const string CLEAR_GAME = "clear_game";
    
    static MyFacade()
    {
        m_instance = new MyFacade();
    }

    public static MyFacade GetInstance()
    {
        return m_instance as MyFacade;
    }

    public void Launch()
    {
        SendNotification(INIT_LEVELS);
        SendNotification(START_UP);
    }

    protected override void InitializeView()
    {
        base.InitializeView();
    }

    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }

    protected override void InitializeController()
    {
        base.InitializeController();

        RegisterCommand(START_UP, typeof(StartUpCommand));
        RegisterCommand(EXIT, typeof(ExitCommand));
        RegisterCommand(SHOW_LEADERS,typeof(ShowLeaderCommand));
        RegisterCommand(LEADER_ADDED, typeof(LeaderAddedCommand));
        RegisterCommand(INIT_LEVELS, typeof(CreateLevelsCommand));
        RegisterCommand(PLAY, typeof(PlayCommand));
        RegisterCommand(ENEMY_DESTROYED, typeof(DestroyEnemyCommand));
        RegisterCommand(PLAY_NEXT_LEVEL, typeof(Play2SubCommand));
        RegisterCommand(RESET_TRIES, typeof(ResetTriesCommand));
        RegisterCommand(CLEAR_GAME, typeof(ClearGameCommand));
    }


    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new LevelProxy(LevelProxy.NAME));
        RegisterProxy(new LeadersProxy(LeadersProxy.NAME));
        RegisterProxy(new OtherDataProxy(OtherDataProxy.NAME));
        RegisterProxy(new PlayerDataProxy(PlayerDataProxy.NAME));
        RegisterProxy(new EnemyProxy(EnemyProxy.NAME));
    }
}